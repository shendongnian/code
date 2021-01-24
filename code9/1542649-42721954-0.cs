    namespace WindowsFormsApplication3
    {
        using System;
        using System.Windows.Forms;
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                this.InitializeComponent();
                this.button_Load.Click += Button_Load_Click;
            }
    
            private void Button_Load_Click(object sender, EventArgs e)
            {
                var form2 = new Form2();
                if(this.checkBox1.Checked == true)
                {
                    form2.IndexOfGraphToShow = 1;
                }
    
                if(this.checkBox2.Checked == true)
                {
                    form2.IndexOfGraphToShow = 2;
                }
    
                if(form2.IndexOfGraphToShow ==1 || form2.IndexOfGraphToShow == 2)
                {
                    form2.Show();
                    return;
                }
    
                MessageBox.Show("Select which graph to show", "Choose graph", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form2.Dispose();
            }
        }
    }
