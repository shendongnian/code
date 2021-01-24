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
        // We're on the UI thread, and we will stay on the UI
        // thread *at least* until we hit the `await` keyword.
        SomeMethodA();
        // We're still on the UI thread, but if `SomeOtherMethodAsync`
        // is a genuinely asynchronous method, we will go asynchronous
        // as soon as `SomeOtherMethodAsync` hits the its `await` on a
        // `Task` that does not transition to `Completed` state immediately.
        bool variable = await SomeOtherMethodAsync();
        // If you need stronger guarantees that `SomeOtherMethodAsync`
        // will stay off the UI thread, you can wrap it in Task.Run, so
        // that its synchronous portions run on a thread pool thread.
        // bool variable = await Task.Run(() => SomeOtherMethodAsync());
        // We're back on the UI thread for the remainder of this method.
        if ( variable ) SomeMethodB();
        // Still on the UI thread.
        SomeMethodC();
    }
