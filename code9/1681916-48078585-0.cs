    public static bool CacheAuthObjects( )
    {
        SqlCommand cmd = new SqlCommand( "SELECT ..." );
        cmd.Connection = Engine.CreateDefaultDBConnection();
        cmd.Connection.Open();
        SqlDataReader dbr = cmd.ExecuteReader();
        try
        {
            while ( dbr.Read() )
            {
                CachedData.AuthObjects.Add( new AuthObject( dbr ) );
            }
            dbr.Close();
        }
        catch
        {
            // log, send mail..
            return false;
        }
        finally
        {
            cmd.Connection.Close();
        }
        return true;
    }
As you can see, I use ExecuteReader now. And I am creating a Task out of this method, put it in a list, start all of the tasks and await them, all in the main caching method, like this:
    public static async Task<bool> CacheAllAsync()
    {
        // creating the list for the tasks
        List<Task<bool>> cachingTasks = new List<Task<bool>>();
        // adding the task
        cachingTasks.Add( new Task<bool>(AuthObjectDB.CacheAuthObjects ) );
        // ... adding the rest of the tasks....
        // starting the tasks
        foreach ( Task t in cachingTasks )
            t.Start();
        
        // awaiting the tasks to complete
        Task<bool[]> task = Task.WhenAll( cachingTasks );
        await task;
   
        // checking if any of the tasks failed to complete
        foreach ( bool b in task.Result )
            if ( !b ) return false;
        return true;
    }
Ivan, did you mean something like this? I like this even more, since the logic is spread more evenly. I guess you suggested ExecuteReader if I were to read the data inside od the main caching method. Or am I doing something wrong? The code is actually working well, the UI is responsive and the data is being loaded.
