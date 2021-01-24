    private async void MyButton_Click(object sender, EventArgs args)
    {
        SetWorkingModeUI();
        try 
        {
            var tasks = new[] {
                       AsyncCall1(),
                       AsyncCall2(),
                       AsyncCall3()
            };
            await Task.WhenAll(tasks);
            SetIdleModeUI();
        }
        catch(Exception exc)
        {
            SomeProperErrorHandlerAndLogger(exc);
        }
    }
