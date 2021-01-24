    private void button1_Click(object sender, EventArgs e)
            {
                int i;
    
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 200;
    
                for (i = 0; i <= 200; i++)
                {
                    progressBar1.Value = i;
                }
    
            }
