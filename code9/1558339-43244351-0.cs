    private void button1_Click(object sender, EventArgs e)
    {
        progressBar1.Maximum = 999;
        while (progressBar1.Value < progressBar1.Maximum)
        {
            Thread.Sleep(500);
            progressBar1.Value += (progressBar1.Maximum / 4);
        }
        MessageBox.Show("Done!");
    }
