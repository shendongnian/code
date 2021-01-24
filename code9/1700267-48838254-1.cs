    namespace DlgExample
    {
        public partial class Form2 : Form
        {
            private String _string = string.Empty;
    
            public Form2()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // get the data from the control
                _string = form2TextBox.Text;
    
                // DialogResult.OK result
                DialogResult = System.Windows.Forms.DialogResult.OK;
    
                // close this dialog
                this.Close();
            }
    
            // public property
            public String myString
            {
                get
                {
                    return _string;
                }
            }
        }
    }
