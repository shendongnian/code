    private async void control_SelectionValueChanged(Object sender, EventArgs e)
    {
        try
        {
            await SomeMethodAsync();
        }
        catch (Exception ex)
        {
            // We're an async void, so don't forget to handle exceptions.
            MessageBox.Show(ex.Message);
        }
    }
    private async Task SomeMethodAsync()
    {
        // We're on the UI thread.
        SomeMethodA();
        // We're still on the UI thread, but if `SomeOtherMethodAsync`
        // is a genuinely asynchronous method, we will go asynchronous
        // as soon as `SomeOtherMethodAsync` hits the first `await` on
        // a `Task` that does not transition to `Completed` state immediately.
        bool variable = await SomeOtherMethodAsync();
        // We're back on the UI thread.
        if ( variable ) SomeMethodB();
        // Still on the UI thread.
        SomeMethodC();
    }
