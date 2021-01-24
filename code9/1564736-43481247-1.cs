    Task _backgroundWork;
    CancellationTokenSource _cts;
    private void button2_Click(object sender, EventArgs e)
    {
        if (status.Text == "Stopped")
        {
            if (!generatearticle.IsBusy)
            {
                // started
                status.Text = "Started";
                status.ForeColor = System.Drawing.Color.Green;
                start.Text = "Stop Generating";
                _cts = new CancellationTokenSource();
                _backgroundWork = Task.Run(() => core(_cts.Token), _cts.Token);
            }
        }
        else
        {
            if(!_backgroundWork.IsCompleted)
            {
                _cts.Cancel();
                // started
                status.Text = "Stopped";
                status.ForeColor = System.Drawing.Color.Red;
                start.Text = "Start Generating";
            }
        }
    }
