    public partial class Form1 : Form
    {
        int i;
        public Form1()
        {
            InitializeComponent();
        }
    
        private void btnclick_Click(object sender, EventArgs e)
        {
            for (  i = 0; i < 3; i++)
            {
    
                lblForLoopExample.Text + = i.ToString + ","
                   
    
            }
        }
    }
