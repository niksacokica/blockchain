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
        private int difficulty;
        private int nonce;

        private SHA256 sha = SHA256.Create();

        public block( int ind, string info, string prevHs, int diff, int n ){
            index = ind;
            data = info;
            prevHash = prevHs;
            time = DateTime.Now;
            difficulty = diff;
            nonce = n;
            hash = BitConverter.ToString( sha.ComputeHash( Encoding.UTF8.GetBytes( index.ToString() + time.ToString() + data + prevHash + difficulty.ToString() + nonce.ToString() ) ) ).Replace( "-", "" );
        }

        public int Index{ get => index; }

        public string Data{ get => data; }

        public DateTime Time{ get => time; set{ time = value; hash = BitConverter.ToString( sha.ComputeHash( Encoding.UTF8.GetBytes( index.ToString() + time.ToString() + data + prevHash ) ) ).Replace( "-", "" ); } }

        public string Hash{ get => hash; }

        public string PreviousHash{ get => prevHash; set{ prevHash = value; hash = BitConverter.ToString( sha.ComputeHash( Encoding.UTF8.GetBytes( index.ToString() + time.ToString() + data + prevHash ) ) ).Replace( "-", "" ); } }

        public int Difficulty{ get => difficulty; }

        public int Nonce{ get => nonce; }

        public Dictionary<string, string> ToDictionary(){
            return new Dictionary<string, string>(){
                { "index", index.ToString() },
                { "data", data },
                { "time", time.ToString() },
                { "hash", hash },
                { "prevHash", prevHash },
                { "diff", difficulty.ToString() },
                { "nonce", nonce.ToString() }
            };
        }
    }
}
