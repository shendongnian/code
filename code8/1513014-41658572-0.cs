    public class TcpConnect
    {
        public Thread waitForConnectionThread;
        public event EventHandler ClientConnected;
        public TcpConnect()
        {
            waitForConnectionThread = new Thread(waitForConnection);
        }
        private void waitForConnection()
        {
            server.Start();
            client = server.AcceptTcpClient();
            RaiseClientConnected(new EventArgs());
        }
        protected void RaiseClientConnected(EventArgs args)
        {
            if (ClientConnected != null)
            {
                ClientConnected(this, args);
            }
        }
    }
