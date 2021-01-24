    private async void MyButton_Click(object sender, EventArgs args)
    {
        SetWorkingModeUI();
        try 
        {
            await CreateTableAsync("SomeTableName");
            await CreateTableAsync("OtherTableName");
            await CreateTableAsync("ThirdTableName");
            SetIdleModeUI();
        }
        catch(Exception exc)
        {
            SomeProperErrorHandlerAndLogger(exc);
        }
    }
