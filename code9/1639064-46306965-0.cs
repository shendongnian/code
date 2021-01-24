    [Serializable]
    public class GameMessage
    {
        public string cmd;
        public string data;
        public string seedId;
        public string peerId;
        public byte [] Data{ get { return Encoding.ASCII.GetBytes(this.data); } }
    
        public GameMessage( string cmd, byte[] data, string seedId = null, string peerId = null )
        {
            this.cmd = cmd;
            this.data = Convert.BaseToString64(data);
            this.seedId = seedId;
            this.peerId = peerId;
        }
    }
