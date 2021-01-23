    public async Task YourFunc()
    {
    
        Exception error = null
        try
        {
            await Task.Run(() =>
            {
                //do stuff
             });
        }
        catch(Exception ex)
        {
            error = ex;
        }
        
        MigrationProcessCompleted(error)
    }
    private void MigrationProcessCompleted(Exception error)
    {
         //Check to see if error == null. If it is no error happend, if not deal withthe error.
    }
