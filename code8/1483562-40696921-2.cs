    private async void doWorkButton_Click(object sender, EventArgs e)
    {
        try
        {
            …
            for (i = 0; i < 2000000; i++) { … }
            {
                Data = …
                await ExecuteNonQueryAsync(Data);
            }
        }
        catch
        {
            … // do not let any exceptions escape this handler method
        }
    }
