    public class NetTest : NetworkManager
    {
        private NetworkManager manager;
    
        public void startServerr()
        {
            manager = this;
            manager.StartHost();
        }
    
        public void connectToServer()
        {
            //manager.networkAddress = PlayerPrefs.GetString("oppPlayerIP");
            manager.StartClient();
        }
    
        public override void OnClientConnect(NetworkConnection conn)
        {
            //base.OnClientConnect(conn);
        }
    
        public override void OnClientDisconnect(NetworkConnection conn)
        {
            //base.OnClientDisconnect(conn);
        }
        public override void OnServerConnect(NetworkConnection conn)
        {
            //base.OnServerConnect(conn);
        }
    
        public override void OnServerDisconnect(NetworkConnection conn)
        {
            //base.OnServerDisconnect(conn);
        }
    }
