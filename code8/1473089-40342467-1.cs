    private async void button1_Click(object sender, EventArgs e)
        {
          
            int i;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            for (i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
            }
            await Task.Delay(2000);
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
            }
        }
