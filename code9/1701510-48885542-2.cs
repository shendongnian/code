    private async void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        try
        {
            await AnotherMethod();
        }
        catch (Exception ex)
        {
            await ShowMessageAsync("attention", "an exception occurred: " + ex.message);
        }
     }
