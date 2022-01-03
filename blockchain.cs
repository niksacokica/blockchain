using System.Drawing;
using System.Windows.Forms;

namespace blockchain{
    public partial class Blockchain : Form{
        public Blockchain(){
            InitializeComponent();
        }

        #region shadow_text

        private void chat_Enter( object sender, System.EventArgs e ){
            TextBox tb = ( TextBox )sender;

            if( tb.Text == "YOUR IP:PORT HERE" || tb.Text == "OTHERS IP:PORT HERE" ){
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void chat_Leave( object sender, System.EventArgs e ){
            TextBox tb = ( TextBox )sender;

            if( string.IsNullOrEmpty( tb.Text ) ){
                tb.Text = ( tb.Name == "your_ip_port_chat" ) ? "YOUR IP:PORT HERE" : "OTHERS IP:PORT HERE";
                tb.ForeColor = Color.Gray;
            }
        }

        #endregion
    }
}
