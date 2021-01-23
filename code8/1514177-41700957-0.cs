    public async Task LoginIntoApplication(Button loginButton)
    {
        try
        {
            using (var conn=new OracleConnection(myConnectionString))
            { 
                //OpenAsync runs on the background while the UI thread is released
                await conn.OpenAsync();
                //No exception means connection open
                //At this point we are back on the UI thread.
                loginButton.IsEnabled = false;
                loginWindow.Hide();
                testWindow = new TestWindow();
                testWindow.Show();
                var someCommand=new OracleCommand(myQuery,conn);
                //Run a query asynchronously
                using(var reader=await someCommand.ExecuteReaderAsync())
                {
                   //Work with the reader's results
                }
        }
        catch(Exception exc)
        {
            //Oracle refused the connection
            loginButton.IsEnabled = true;
        }
    }
