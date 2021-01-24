    private bool keepRunning = true;
    
    private void Preiststop_Click(object sender, EventArgs e)
    {
        keepRunning = false;
    }
    private async void Preist_Click(object sender, EventArgs e)
    {
        keepRunning = true;
        await Task.Run(() => {
            while (keepRunning)
            {
                SendKeys.Send(" ");
                Thread.Sleep(5000);
            }
        });
    }
