    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
        }
 
        const int port = 3000;
        ManualResetEvent _closing = new ManualResetEvent(false);
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap("Image");
            var ip = IPAddress.Parse("127.0.0.1");
            label1.Text = "IP Address:" + ip;
            Task.Run(() => Listen());
        }
        private void Listen()
        {
            var tcpListener = new TcpListener(ip, port);
            tcpListener.Start();
            while (!_closing.WaitOne(100))
            {
                if (tcpListener.Pending())
                {
                    tcpListener.AcceptSocketAsync().ContinueWith( (socket) =>
                    {
                        NetworkStream ns = null;
                        MemoryStream ms = null;
                        try
                        {
                            if (!socket.Connected) return;
                            label2.Invoke(() => label2.Text = "Connected");
                            ns = new NetworkStream(socket);
                            ms = new MemoryStream();
                            ns.CopyTo(ms); // Copies from the NetworkStream to the MemoryStream. Should use a default buffer size of 81920
                            var msg = ms.ToArray();
                            var parts = Encoding.ASCII.GetString(msg).Split('\t');
                            if (parts.Length != 3) return; // simple error check
                            // You could use TryParse for error checking                     
                            var w = (double.Parse(part[1]) / 0.0347) + 60.0; 
                            var x = (double.Parse(part[2]) / 0.0335) + 656.0;                              
                            string tag = "";
                            Color color;
                            if (part[0].Equals("1", StringComparison.Ordinal))
                            {
                                tag = $"Tag ID_Blue: {part[0]}\tX {part[2]}\tY: {part[1]};
                                color = Color.Blue;
                            }
                            else if (part[0].Equals("2", StringComparison.Ordinal))
                            {
                                tag = $"Tag ID_Red: {part[0]}\tX {part[2]}\tY: {part[1]};
                                color = Color.Red;
                            }
                            else return; // Shouldn't hit this
                               
                            UpdateUiDrawRectangle(tag, color, (int)x, (int)w);
                                                  
                            // Your code was writing the same message back
                            ns.Write(msg, 0, msg.Length);
                        }
                        finally
                        {
                            // Need to cleanup resources
                            ns?.Dispose();
                            ms?.Dispose();
                            socket.Close();
                        }
                    }
                }
            }
        }
        private void UpdateUiDrawRectangle(string tag, Color color, int x, int w)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(() => UpdateUiDrawRectange(tag, color, x, w));
                return;
            }
            Graphics g = null;
            Pen pen = null;
            try
            {
                pen = new Pen(color, 3);
                g = pictureBox1.CreateGraphics();
                g.DrawRectangle(pen, x, w, 6, 6);
                textBox2.Text = tag;
            }
            finally
            {
                g?.Dispose();
                pen?.Dispose();
            }
            pictureBox1.Invalidate(); // Instead of Refresh
        }
