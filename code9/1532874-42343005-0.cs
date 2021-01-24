    private async void Form1_Load(object sender, EventArgs e)
    {
         await Task.Run(() => longRunningRoutine())
    }
    public void longRunningRoutine()
    {
        System.Threading.Thread.Sleep(10000);
    }
