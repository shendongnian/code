    public partial class GetPass : Form
        {
            // Use a texBox called textBox1 and a button called btn_confirm
            private string refPassword;
    
            public GetPass(string password)
            {
                InitializeComponent();
                refPassword = password;
            }
    
            private void btn_confirm_Click(object sender, EventArgs e)
            {
                string password = textBox1.Text;
                if (password.CompareTo(refPassword) == 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
