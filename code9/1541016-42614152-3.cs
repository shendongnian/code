    public partial class Form1 : Form
    {
        private readonly DataInput dataInput;
        public Form1()
        {
            InitializeComponent();
            dataInput = new DataInput("COM3");
            dataInput.dataReceived += OnDataReceived;
        }
        private void OnDataReceived(string Data)
        {
            //Do whatever you want with the data
        }
    }
