using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blockchain{
    public partial class Blockchain : Form{

        private TcpListener listener;
        private List<TcpClient> connected = new List<TcpClient>();
        private List<TcpClient> connect = new List<TcpClient>();
        private List<block> blocks = new List<block>();

        delegate void appendTextCallback( TextBox tb, string text );
        delegate void refreshCallback();

        private int diff = 1;

        public Blockchain() => InitializeComponent();

        private void appendText( TextBox tb, string text ){
            if( tb.InvokeRequired )
                tb.Invoke( new appendTextCallback( appendText ), new object[] { tb, text } );
            else
                tb.AppendText( text + "\r\n" );
        }

        private void refreshBlockchainLog(){
            if( blockchain_chat.InvokeRequired )
                blockchain_chat.Invoke( new refreshCallback( refreshBlockchainLog ), new object[] { } );
            else{
                blockchain_chat.Clear();
                for( int i=0; i<blocks.Count; i++ )
                    appendText( blockchain_chat, "Indeks: " + blocks[i].Index.ToString() + "\r\nPodatek: " + blocks[i].Data + "\r\nČas: " + blocks[i].Time.ToString() + "\r\nHash: " + blocks[i].Hash + "\r\nPrejšnji hash: " + blocks[i].PreviousHash + "\r\nDiff: " + blocks[i].Difficulty + "\r\nNonce: " + blocks[i].Nonce + "\r\n" );
            }
        }

        #region shadow_text

        private void chat_Enter( object sender, EventArgs e ){
            TextBox tb = ( TextBox )sender;

            if( tb.Text == "YOUR IP:PORT HERE" || tb.Text == "OTHERS IP:PORT HERE" ){
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void chat_Leave( object sender, EventArgs e ){
            TextBox tb = ( TextBox )sender;

            if( string.IsNullOrEmpty( tb.Text ) ){
                tb.Text = ( tb.Name == "your_ip_port_chat" ) ? "YOUR IP:PORT HERE" : "OTHERS IP:PORT HERE";
                tb.ForeColor = Color.Gray;
            }
        }

        #endregion

        #region server_stuff

        private void callback( IAsyncResult iar ){
            TcpClient client = listener.EndAcceptTcpClient( iar );
            connected.Add( client );

            listener.BeginAcceptTcpClient( new AsyncCallback( callback ), null );

            appendText( log_chat, "Client " + client.Client.RemoteEndPoint + " has connected!" );

            NetworkStream ns = client.GetStream();

            while( client.Connected ){
                byte[] rec = new byte[256];
                try{
                    ns.Read( rec, 0, rec.Length );
                }catch{}

                Task.Run( () => {
                    string read = Encoding.UTF8.GetString( rec, 0, rec.Length );
                    if( !string.IsNullOrEmpty( @read ) ){
                        Dictionary<string, string> msg = JsonConvert.DeserializeObject<Dictionary<string, string>>( @read );
                        Dictionary<string, string> send = new Dictionary<string, string>();

                        if( msg.ContainsKey( "length" ) ){
                            if( Int32.Parse( msg["length"] ) > blocks.Count ){
                                send.Add( "send", "" );

                                string json = JsonConvert.SerializeObject( send );
                                byte[] bytes = Encoding.UTF8.GetBytes( json.ToCharArray(), 0, json.Length );
                                client.GetStream().Write( bytes, 0, bytes.Length );
                            }
                            else if( Int32.Parse( msg["length"] ) < blocks.Count){
                                for(int i=0; i<blocks.Count; i++){
                                    send = blocks[i].ToDictionary();
                                    send.Add( "replace", "" );

                                    string json = JsonConvert.SerializeObject( send );
                                    byte[] bytes = Encoding.UTF8.GetBytes( json.ToCharArray(), 0, json.Length );
                                    client.GetStream().Write( bytes, 0, bytes.Length );
                                }
                            }
                        }else if( msg.ContainsKey( "replace" ) ){
                            block bl = new block( Int32.Parse( msg["index"] ), msg["data"], msg["prevHash"], Int32.Parse( msg["diff"] ), Int32.Parse( msg["nonce"] ) ){
                                Time = Convert.ToDateTime( msg["time"] )
                            };

                            if( blocks.Count <= bl.Index )
                                blocks.Add( bl );
                            else if( blocks[bl.Index].Index == bl.Index )
                                blocks[bl.Index] = bl;
                            else{
                                blocks.Add( bl );
                                blocks = blocks.OrderBy( o => o.Index ).ToList();
                            }

                            refreshBlockchainLog();
                        }else if( msg.ContainsKey( "block" ) ){
                            block bl = new block( Int32.Parse( msg["index"] ), msg["data"], msg["prevHash"], Int32.Parse( msg["diff"] ), Int32.Parse( msg["nonce"] ) ){
                                Time = Convert.ToDateTime( msg["time"] )
                            };
                           
                            blocks.Add( bl );
                            refreshBlockchainLog();
                        }
                    }
                });
            }
        }

        private void startServer( string ipPort ){
            start_button.Enabled = false;
            your_ip_port_chat.Enabled = false;

            appendText( log_chat, "Started server!" );

            listener = new TcpListener( IPAddress.Parse( ipPort.Split( ':' )[0] ), Int32.Parse( ipPort.Split( ':' )[1] ) );
            listener.Start();
            listener.BeginAcceptTcpClient( new AsyncCallback( callback ), null );
        }

        private void start_button_Click( object sender, EventArgs e ){
            if( !checkIfIpPort( your_ip_port_chat.Text ) )
                    MessageBox.Show( "Invalid IP/PORT!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            else
                startServer( your_ip_port_chat.Text );
        }

        private void your_ip_port_chat_KeyPress( object sender, KeyPressEventArgs e ){
            if( e.KeyChar == ( char )13 && !string.IsNullOrEmpty( your_ip_port_chat.Text ) ){
                if( !checkIfIpPort( your_ip_port_chat.Text ) )
                    MessageBox.Show( "Invalid IP/PORT!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                else
                    startServer( your_ip_port_chat.Text );
            }
        }

        #endregion

        #region connections

        private void receive( TcpClient client ){
            while( client.Connected ){
                byte[] rec = new byte[256];
                try{
                    client.GetStream().Read( rec, 0, rec.Length );
                }catch{}

                Task.Run( () => {
                    string read = Encoding.UTF8.GetString( rec, 0, rec.Length );
                    if( !string.IsNullOrEmpty( @read ) ){
                        Dictionary<string, string> msg = JsonConvert.DeserializeObject<Dictionary<string, string>>( @read );
                        Dictionary<string, string> send = new Dictionary<string, string>();

                        if( msg.ContainsKey("send") ){
                            for(int i=0; i<blocks.Count; i++){
                                send = blocks[i].ToDictionary();
                                send.Add( "replace", "" );

                                string json = JsonConvert.SerializeObject( send );
                                byte[] bytes = Encoding.UTF8.GetBytes( json.ToCharArray(), 0, json.Length );
                                client.GetStream().Write( bytes, 0, bytes.Length );
                            }
                        }else if( msg.ContainsKey( "replace" ) ){
                            block bl = new block( Int32.Parse( msg["index"] ), msg["data"], msg["prevHash"], Int32.Parse( msg["diff"] ), Int32.Parse( msg["nonce"] ) ){
                                Time = Convert.ToDateTime( msg["time"] )
                            };

                            if( blocks.Count <= bl.Index )
                                blocks.Add( bl );
                            else if( blocks[bl.Index].Index == bl.Index )
                                blocks[bl.Index] = bl;
                            else{
                                blocks.Add( bl );
                                blocks = blocks.OrderBy( o => o.Index ).ToList();
                            }

                            refreshBlockchainLog();
                        }else if( msg.ContainsKey( "block" ) ){
                            block bl = new block( Int32.Parse( msg["index"] ), msg["data"], msg["prevHash"], Int32.Parse( msg["diff"] ), Int32.Parse( msg["nonce"] ) ){
                                Time = Convert.ToDateTime( msg["time"] )
                            };
                           
                            blocks.Add( bl );
                            refreshBlockchainLog();
                        }
                    }
                });
            }
        }

        private void connectToServer( string ipPort ){
            other_ip_port_chat.Enabled = false;
            connect_button.Enabled = false;

            TcpClient client;

            try{
                client = new TcpClient( ipPort.Split( ':' )[0], Int32.Parse( ipPort.Split( ':' )[1] ) );
                connect.Add( client );
            }catch( Exception ex ){
                MessageBox.Show( ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                other_ip_port_chat.Enabled = true;
                connect_button.Enabled = true;
                return;
            }

            appendText( log_chat, "Succesfully connected to" + ipPort + "!" );
            Task.Run( () => receive( client ) );

            other_ip_port_chat.Enabled = true;
            connect_button.Enabled = true;

            Dictionary<string, string> send = new Dictionary<string, string>(){
                { "length", blocks.Count.ToString() }
            };
            string json = JsonConvert.SerializeObject( send );
            byte[] bytes = Encoding.UTF8.GetBytes( json.ToCharArray(), 0, json.Length );
            client.GetStream().Write( bytes, 0, bytes.Length );
        }

        private void connect_button_Click( object sender, EventArgs e ){
            if( !checkIfIpPort( other_ip_port_chat.Text ) )
                    MessageBox.Show( "Invalid IP/PORT!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            else
                connectToServer( other_ip_port_chat.Text );
        }

        private void other_ip_port_chat_KeyPress( object sender, KeyPressEventArgs e ){
            if( e.KeyChar == ( char )13 && !string.IsNullOrEmpty( other_ip_port_chat.Text ) ){
                if( !checkIfIpPort( other_ip_port_chat.Text ) )
                    MessageBox.Show( "Invalid IP/PORT!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                else
                    startServer( other_ip_port_chat.Text );
            }
        }

        #endregion

        private bool checkIfIpPort( string sus ){
            if( sus.Count( d => d == '.' ) != 3 || sus.Count( d => d == ':' ) != 1 )
                return false;

            string[] check = sus.Split( '.' );
            for( int i=0; i < check.Length - 1; i++ ){
                try{
                    int num = Int32.Parse( check[i] );

                    if( num > 255 || num < 0 )
                        return false;
                }
                catch{
                    return false;
                }
            }

            check = check[check.Length - 1].Split( ':' );
            try{
                int num = Int32.Parse( check[0] );
                if( num > 255 || num < 0 )
                    return false;

                num= Int32.Parse( check[1] );
                if( num > 65353 || num < 0 )
                    return false;
            }catch{
                return false;
            }

            return true;
        }

        private void mine_button_Click( object sender, EventArgs e ){
            mine_button.Enabled = false;

            int n = 0;
            block bl;
            while( true ){
                bl = new block( blocks.Count, "Block NO." + blocks.Count, ( blocks.Count == 0 ) ? "0" : blocks[blocks.Count-1].Hash, diff, n );

                string starter = "".PadLeft( diff, '0' );
                if( bl.Hash.StartsWith( starter ) )
                    break;
                else
                    n++;
                if( n % 50000 == 0 )
                    appendText( log_chat, "Failed hash: " + bl.Hash );
            }

            mine_button.Enabled = true;

            appendText(log_chat, "Successful hash: " + bl.Hash);
            blocks.Add( bl );

            refreshBlockchainLog();
        
            foreach( TcpClient client in connected.ToArray() ){
                Dictionary<string, string> send = bl.ToDictionary();
                send.Add( "block", "" );
                string json = JsonConvert.SerializeObject( send );

                byte[] bytes = Encoding.UTF8.GetBytes( json.ToCharArray(), 0, json.Length );

                client.GetStream().Write( bytes, 0, bytes.Length );
            }

            foreach( TcpClient client in connect.ToArray() ){
                Dictionary<string, string> send = bl.ToDictionary();
                send.Add( "block", "" );
                string json = JsonConvert.SerializeObject( send );

                byte[] bytes = Encoding.UTF8.GetBytes( json.ToCharArray(), 0, json.Length );

                client.GetStream().Write( bytes, 0, bytes.Length );
            }
        }
    }
}
