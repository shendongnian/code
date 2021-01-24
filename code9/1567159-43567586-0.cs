    // Deadlocks
    public void button2_Click(object sender, EventArgs e)
    {
        var task = GetNews();
        task.Wait();
        MessageBox.Show(task.Result);
    }
    // Doesn't deadlock
    public async void button3_Click(object sender, EventArgs e)
    {
        var result = await GetNews();
        MessageBox.Show(result);
    }
    // Doesn't deadlock
    public void button4_Click(object sender, EventArgs e)
    {
        var task = GetNews(false);
        task.Wait();
        MessageBox.Show(task.Result);
    }
    // Doesn't deadlock
    public void button5_Click(object sender, EventArgs e)
    {
        var task = Task<string>.Run(async () => await GetNews());
        task.Wait();
        MessageBox.Show(task.Result);
    }
    // The boolean option is just so that I don't have to write two example methods :)
    // You obviously don't have to pass this as a parameter, and can just directly call ConfigureAwait
    public async Task<string> GetNews(bool continueOnCapturedContext = true)
    {
        await Task.Delay(100).ConfigureAwait(continueOnCapturedContext: continueOnCapturedContext);
        return "hello";
    }
