     public delegate void Message(string message, IPAddress from);
        public class Listener : IDisposable
        {
            private readonly TcpListener _tcp;
            private Message _OnRecieve;
            private Thread _listenThread;
            private bool IsStopped = false;
            public Listener(IPAddress ip, int port, Message f)
            {
                _tcp = new TcpListener(ip, port);
                _OnRecieve = f;
            }
            public void Start()
            {
                _listenThread = new Thread(ListenForClients);
                _listenThread.Start();
            }
            public void Stop()
            {
                if (_tcp != null)
                {
                    _listenThread.Abort();
                    _tcp.Stop();
                    IsStopped = true;
                }
            }
            private void ListenForClients()
            {
                _tcp.Start();
                while (!IsStopped)
                {
                    TcpClient client = _tcp.AcceptTcpClient();
                    var clientThread = new Thread(HandleClientComm);
                    clientThread.Start(client);
                }
            }
            private void HandleClientComm(object client)
            {
                ReadMessage((TcpClient)client);
            }
            void IDisposable.Dispose()
            {
                if (_tcp != null)
                {
                    _listenThread.Abort();
                    _tcp.Stop();
                    IsStopped = true;
                }
            }
            private void ReadMessage(TcpClient client)
            {
                try
                {
                    NetworkStream ns = client.GetStream();
                    string msg = ... /// read message
                    _OnRecieve(msg,client.(client.Client.RemoteEndPoint as IPEndPoint).Address;
                    client.Close();  
                }
                catch (Exception exc)
                {
                  
                    client.Close();
                    throw exc;
                }
            }
        }
