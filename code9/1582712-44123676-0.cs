    private async void Button_MouseEnter(object sender, EventArgs e)
    {
        try
        {
            await Task.Delay(1000, cancellationTokenSource.Token);
            button.BackgroundImage = bmp2;
            await Task.Delay(1000, cancellationTokenSource.Token);
            button.BackgroundImage = bmp3;
        }
        catch (TaskCanceledException) { }
    }
    private void Button_MouseLeave(object sender, EventArgs e)
    {
        cancellationTokenSource.Cancel();
        button.BackgroundImage = bmp1;
        cancellationTokenSource = new CancellationTokenSource();
    }
