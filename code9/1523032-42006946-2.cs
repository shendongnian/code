    public sealed partial class MainPage : Page
    {
        GameHost host;
    
        public MainPage (GameHost _host)
        {    
            host = _host;
        }
        public void Init(GameHost host)
        {    
            if (host.playerInfo.Count() >= 2) // now it should have the desired items
            {
                //Do stuff
            }
        }
    }
