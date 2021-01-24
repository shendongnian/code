    {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                PushData();
            }
    
            public void PushData()
            {
                Form2 fr = new Form2();
                // function to reading .csv file
                if (checkBox1.Checked==true)
                {
                    progressBar1.Value += 1;
                    //update data to SQL Server
    
                }
    
                else
                {
    
                    timer1.Stop();
    
                    MessageBox.Show("Error message");
    
                    timer1.Start();
    
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                timer1.Start();
            }
        }
