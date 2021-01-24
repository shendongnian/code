    namespace Motor
    {
    public partial class Form1 : Form
    {
        SerialPort ComPort = new SerialPort();
        string InputData = String.Empty;
        delegate void SetTextCallback(string text);
        public Form1()
        {
            InitializeComponent();
            ComPort.DataReceived +=
                new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);
        }
        private async void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            var size = ComPort.ReadBufferSize;
            var data = new byte[size];
            await ComPort.BaseStream.ReadAsync(data,0,size);
            InputData += ComPort.Encoding.GetString(data);
            SetText(InputData);
        }
        private void SetText(string text)
        {
            if (text.Contains("CM"))
            {
                // process the text content here
            }
        }
        
    }
    }
