    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello!");
        }
    
        public void ShowDialog()
        {
            button1_Click(null, new EventArgs());
        }
    }
