    public partial class InputWindow : Form
    {
        DataTransfer transferDel;
        public InputWindow(DataTransfer del)
        {
            InitializeComponent();
            transferDel = del;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string data = textBox1.Text;
            transferDel.Invoke(data);
        }
    }
