    public delegate void DataTransfer(string data);
    public partial class MainWindow : Window
    {
        public DataTransfer transferDelegate;
        public MainWindow()
        {
            InitializeComponent();
            transferDelegate += new DataTransfer(DataMethod);
        }
        public void DataMethod(string data)
        {
            // Do what you want with your data.
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Window2 win = new Window2(transferDelegate);
            win.Show();
        }
    }
