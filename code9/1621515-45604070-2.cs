    public delegate void DataTransfer(string data);
    public partial class Form1 : Form
    {
        public DataTransfer transferDelegate;
        public Form1()
        {
            InitializeComponent();
            transferDelegate += new DataTransfer(DataMethod);
        }
        public void DataMethod(string data)
        {
            // Do what you want with your data.
            MessageBox.Show(data);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InputWindow win = new InputWindow(transferDelegate);
            win.Show();
        }
    }
