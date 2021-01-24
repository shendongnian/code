    private bool ConnectSocket()
        {
            try
            {                
                this.soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                System.Net.IPAddress adresa = System.Net.IPAddress.Parse(Properties.Settings.Default.server_ip);
                IPEndPoint EndPoint = new IPEndPoint(adresa, 0x9de);
                this.soket.Blocking = false;
                AsyncCallback callback = new AsyncCallback(this.OnSocketConnect);
                this.soket.BeginConnect(EndPoint, callback, this.soket);
                if(this.soket.Connected) Console.WriteLine("Uspesno je konektovan socket");
                return true;
            }
            catch(SocketException ex)
            {
                MessageBox.Show("Dogodila se greska prilikom povezivanja na server");
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
