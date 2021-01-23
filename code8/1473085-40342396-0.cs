    private void button1_Click(object sender, EventArgs e)
        {
            int i;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
    
            for (i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                Thread.Sleep(100);    // only for testing. Blocks your thread.
            }
            progressBar1.Value = 0;   // no if required, as after your loop you are at maximum
        }
