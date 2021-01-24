    private async void btnCallWebService_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "Running method...";
        string result = await LongRunningMethod();
        lblStatus.Text = result;
    }
    private async Task<string> LongRunningMethod()
    {
        await Task.Delay(5000);
        return "Method complete";
    }
