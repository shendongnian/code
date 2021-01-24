    namespace Motor
    {
         delegate void SetTextCallback(string text);
        public partial class Form1 : Form
        {
            SerialPort ComPort = new SerialPort();
            string InputData = String.Empty;
             SetTextCallback st;
    
            public Form1()
            {
                InitializeComponent();
                st = new SetTextCallback(SetText);
               
            }
        private void Form1_Load(object sender, EventArgs e)
        {
             OpenPort();
        }
            private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
            {
                InputData = ComPort.ReadLine();
                if (InputData != String.Empty)
                {
                   this.Invoke(st,new object[] { InputData});
                }
            }
    
            private void SetText(string text)
            {
               Console.WriteLine(text);//To check the return value
                if (text.Contains("CM")) 
                {
                    // process the text content here
                }
            }
        }
    }
