using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace blockchain{
    class block{
        private int index;
        private string data;
        private DateTime time;
        private string hash;
        private string prevHash;

        public block( int ind, string info, string prevHs ){
            index = ind;
            data = info;
            prevHash = prevHs;
            time = DateTime.Now;
            SHA256 sha = SHA256.Create();
            hash = BitConverter.ToString( sha.ComputeHash( Encoding.UTF8.GetBytes( index.ToString() + time.ToString() + data + prevHash ) ) ).Replace( "-", "" );
        }

        public int Index{ get => index; }

        public string Data{ get => data; }

        public DateTime Time{ get => time; }

        public string Hash{ get => hash; }

        public string PreviousHash{ get => prevHash; }

        public string ToJson(){
            Dictionary<string, string> forJson = new Dictionary<string, string>(){
                { "index", index.ToString() },
                { "data", data },
                { "time", time.ToString() },
                { "hash", hash },
                { "prevHash", prevHash }
            };

            return JsonConvert.SerializeObject( forJson );
        }
    }
}
