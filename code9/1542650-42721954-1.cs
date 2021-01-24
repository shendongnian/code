    namespace WindowsFormsApplication3
    {
        using System;
        using System.Windows.Forms;
    
        public partial class Form2 : Form
        {
            public Form2()
            {
                this.InitializeComponent();
                this.Load += Form2_Load;
            }
    
            public int IndexOfGraphToShow { get; set; }
    
            private void Form2_Load(object sender, EventArgs e)
            {
                if(this.IndexOfGraphToShow == 1)
                {
                    //  TODO: Show first graph
                }
                else if(this.IndexOfGraphToShow == 2)
                {
                    //  TODO: Show second graph
                }
            }
        }
    }
