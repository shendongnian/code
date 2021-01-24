    public partial class Window2 : Window
    {
        DataTransfer transferDel;
        public Window2(DataTransfer del)
        {
            InitializeComponent();
            transferDel = del;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string data = "Hello, World!"; // Your string data to pass.
            transferDel.Invoke(data);
        }
    }
