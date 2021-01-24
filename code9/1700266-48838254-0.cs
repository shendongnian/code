    namespace DlgExample
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 form2 = new Form2();
    
                // look a good result
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    // get the data and put it where you need it
                    form1TextBox.Text = form2.myString;
                }
    
            }
        }
    }
