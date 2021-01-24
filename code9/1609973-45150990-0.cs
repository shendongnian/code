    private async void button1_Click(object sender, EventArgs e)
    {
        await CallMethodAsync();
    }
    private async Task CallMethodAsync()
    {
        this.progressBar1.Value = 0;
        this.progressBar1.Maximum = 1000;
        await ExecuteMethodAsync();
    }
    private async Task ExecuteMethodAsync()
    {
        for (int percentComplete = 0; percentComplete < 1000; percentComplete++)
        {
            await Task.Delay(10);
            progressBar1.Increment(1);
        }
    }
