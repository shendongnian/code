    private async void button2_Click(object sender, EventArgs e)
    {
        var progressHandler = new Progress<string>(value =>
        {
            label2.Text = value;
        });
        var progress = progressHandler as IProgress<string>;
        await Task.Run(() =>
        {
            for (int i = 0; i != 100; ++i)
            {
                if (progress != null)
                    progress.Report("Stage " + i);
                Thread.Sleep(100);
            }
        });
        label2.Text = "Completed.";
    }
