    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitSocketServer();
        }
        internal void InitSocketServer()
        {
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            var ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            try
            {
                Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);
                listener.Listen(100);
                listener.BeginAccept(AcceptCallback, listener);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            string data = null;
            while (true)
            {
                var bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }
            MessageBox.Show(handler.RemoteEndPoint + " : " + data);
            byte[] msg = Encoding.ASCII.GetBytes(data);
            handler.Send(msg);
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test button click");
        }
    }
