    public class AsynchronousSocketListener : IDisposable
    {
        Socket listener;
        // Thread signal.
        public ManualResetEvent allDone = new ManualResetEvent(false);
        public AsynchronousSocketListener()
        {
        }
        public void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];
            // Establish the local endpoint for the socket.
            // The DNS name of the computer
            // running the listener is "host.contoso.com".
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            // Create a TCP/IP socket.
            listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);
                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();
                    // Start an asynchronous socket to listen for connections.
                    //Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);
                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }
            }
            catch (ObjectDisposedException)
            {
                //Console.WriteLine("Listener closed.");
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
            }
            //Console.WriteLine("\nPress ENTER to continue...");
            //Console.Read();
        }
        
        //...
        public void StopListening() // Stop Listening
        {
            Socket exListener = Interlocked.Exchange(ref listener, null);
            if (exListener != null)
            {
                exListener.Close();
            }
        }
        public void Dispose()
        {
            StopListening();
        }
    }
