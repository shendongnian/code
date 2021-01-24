    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            using (var loadingScreen = new Form3())
		    {
			    var formResult = loadingScreen.ShowDialog();
			    if (formResult == DialogResult.Cancel)
			    {
			    	// form3 failed
			    }
			    else if (dr == DialogResult.OK)
			    {
			    	// form3 completed
			    }
			
			    loadingScreen.Close();
            }
		}
    }
