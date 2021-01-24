     public partial class Form1 : Form
    {
        List<string> textFiles = new List<string>();
    
        public Form1()
        {
            InitializeComponent();
        }
    
        public void mParsing(List<string> textFiles) { /* parsing logic */ }
        public void iParsing(List<string> textFiles) { /* parsing logic */ }
        public void aParsing(List<string> textFiles) { /* parsing logic */ }
        public void qParsing(List<string> textFiles) { /* parsing logic */ }
    
        public void Summary()
        {
            // Logic to generate summary   
        }
    
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (checkM.Checked == true && checkI.Checked == false && checkA.Checked == false && checkQ.Checked == false)
            {
                Thread worker = new Thread(mOption);
                    if (!worker.IsAlive)
                    {
    
                        worker.Start();
                        frm.Show(); // Displaying Form - Performing Operation.. Please Wait... 
                        btn1.Enabled = false;
                    }
            }
            else if (checkM.Checked == true && checkI.Checked == true && checkA.Checked == false && checkQ.Checked == false)
            {
                Thread worker = new Thread(miOption);
                    if (!worker.IsAlive)
                    {
    
                        worker.Start();
                        frm.Show(); // Displaying Form - Performing Operation.. Please Wait... 
                        btn1.Enabled = false;
                    }
            }            
    
            //So On....
        }
    
    	
            private void mOption()
            {
                mParsing(textFiles);
                Summary();
    
                MethodInvoker inv = delegate
                {
                    frm.Hide();
    
            DialogResult dialogResult = MessageBox.Show("View Summary?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string summary = filepath;
                Process.Start("notepad.exe", summary);
            } 
                    this.btn1.Enabled = true;
    
                };
                this.Invoke(inv);
            }
    		
    		private void miOption()
            {
                mParsing(textFiles);
    			iParsing(textFiles);
                Summary();
    
                MethodInvoker inv = delegate
                {
                    frm.Hide();
    
            DialogResult dialogResult = MessageBox.Show("View Summary?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string summary = filepath;
                Process.Start("notepad.exe", summary);
            } 
                    this.btn1.Enabled = true;
    
                };
                this.Invoke(inv);
            }
    		
    }
