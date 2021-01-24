    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Don't forget to enable Form.KeyPreview in order to receive key down events
            if (e.KeyCode == Keys.Insert)
            {
                Visible = false;
            }
        }
    }
