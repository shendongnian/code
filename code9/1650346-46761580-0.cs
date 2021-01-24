    namespace Test_Form_Controls
    {
        public partial class Form1 : Form
        {
            Label label1;
            public Form1()
            {
                InitializeComponent();
                TextBox txtBox1 = new TextBox();
                txtBox1.Text = "0";
                txtBox1.Location = new Point(100, 25);
                Controls.Add(txtBox1);
                txtBox1.TextChanged += txtBox1_TextChanged;
                label1 = new Label();
                label1.Text = "0";
                label1.Location = new Point(25, 25);
                Controls.Add(label1);
            }
    
            private void txtBox1_TextChanged(object sender, EventArgs e)
            {
                TextBox objTextBox = (TextBox)sender;
                label1.Text = objTextBox.Text;
            }
        }
    }
