    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += MyForm_KeyDown;
        }
        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers & Keys.Shift) != 0 &&
                (e.Modifiers & Keys.Control) != 0 &&
                (e.KeyCode == Keys.Z))
            {
                e.Handled = true;
                richTextBox1.Redo();
            }
        }
    }
