    private async void BtnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            // you dont want user to click twice
            BtnConfirm.Enabled = false;
            // ConfigureAwait(false) configures the task so it doesn't need to block caller thread
            await Somemethod().ConfigureAwait(false);
        }
        finally
        {
            // BeginInvoke prevents thread access exceptions
            BeginInvoke((Action)delegate
            {
                BtnConfirm.Enabled = true;
            });
        }
    }
    private async Task Somemethod()
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
