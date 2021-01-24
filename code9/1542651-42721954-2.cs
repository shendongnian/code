    namespace WindowsFormsApplication3
    {
        using System;
        using System.Windows.Forms;
    
        public partial class Form1 : Form
        {
            private Form2 form2;
    
            public Form1()
            {
                this.InitializeComponent();
                this.button_Load.Click += Button_Load_Click;
            }
    
            private void Button_Load_Click(object sender, EventArgs e)
            {
                if(this.form2 != null)
                    this.form2.Dispose();
    
                this.form2 = new Form2();
                if(this.checkBox1.Checked == true)
                {
                    this.form2.IndexOfGraphToShow = 1;
                }
    
                if(this.checkBox2.Checked == true)
                {
                    this.form2.IndexOfGraphToShow = 2;
                }
    
                if(this.form2.IndexOfGraphToShow == 1 || this.form2.IndexOfGraphToShow == 2)
                {
                    this.form2.Show();
                    return;
                }
    
                MessageBox.Show("Select which graph to show", "Choose graph", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form2.Dispose();
            }
        }
    }
