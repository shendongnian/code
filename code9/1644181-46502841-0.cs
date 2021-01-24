    private CancellationTokenSource loopCanceller = new CancellationTokenSource();
    private void button1_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    this.loopCanceller.Token.ThrowIfCancellationRequested(); // exit, if cancelled
                    // simulating half a second of work
                    Thread.Sleep(500);
                    // UI update, Invoke needed because we are in another thread
                    Invoke((Action)(() => this.Text = "Iteration " + i)); 
                }
            }
            catch (OperationCanceledException ex)
            {
                loopCanceller = new CancellationTokenSource(); // resetting the canceller
                Invoke((Action)(() => this.Text = "Thread cancelled"));
            }
        }, loopCanceller.Token);
    }
    private void button2_Click(object sender, EventArgs e)
    {
        loopCanceller.Cancel();
    }
