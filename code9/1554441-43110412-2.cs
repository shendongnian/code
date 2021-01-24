    public partial class Form1 : Form
    {
        private int _port = 28000;
        private string _multicastGroupAddress = "239.1.1.1";
        private UdpClient _sender;
        private UdpClient _receiver;
        
        private Thread _receiveThread;
        private void UpdateMessages(IPEndPoint sender, string message)
        {
            textBox1.Text += $"{sender} | {message}\r\n";
        }
        public Form1()
        {
            InitializeComponent();
            _receiver = new UdpClient();
            _receiver.JoinMulticastGroup(IPAddress.Parse(_multicastGroupAddress));
            _receiver.Client.Bind(new IPEndPoint(IPAddress.Any, _port));
            _receiveThread = new Thread(() =>
            {
                while (true)
                {
                    IPEndPoint sentBy = new IPEndPoint(IPAddress.Any, _port);
                    var dataGram = _receiver.Receive(ref sentBy);
                    textBox1.BeginInvoke(
                        new Action<IPEndPoint, string>(UpdateMessages), 
                        sentBy, 
                        Encoding.UTF8.GetString(dataGram));
                }
            });
            _receiveThread.IsBackground = true;
            _receiveThread.Start();
            _sender = new UdpClient();
            _sender.JoinMulticastGroup(IPAddress.Parse(_multicastGroupAddress));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var data = Encoding.UTF8.GetBytes(textBox2.Text);
            _sender.Send(data, data.Length, new IPEndPoint(IPAddress.Broadcast, _port));
        }
    }
