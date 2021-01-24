            public void NetworkGet(string s, System.Net.IPAddress ip)
            {
               // do anything
            }
            public Server()
            {
                listener = new Network.Listener(System.Net.IPAddress.Any, Properties.Main.Default.NetworkPort, NetworkGet);
                listener.Start();  
            }
