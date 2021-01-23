     public partial class EditableLabelControl : UserControl
    {
        public EditableLabelControl()
        {
            InitializeComponent();
        }
        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Visible = true;
            textBox1.BringToFront();
            textBox1.Focus();
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
            textBox1.Visible = false;
            textBox1.SendToBack();
        }
    }
 
