    // Time-out in milliseconds, after which auth process will be terminated, whether permission granted or not
    var timeoutMs = 60*1000; 
    var credCts = new CancellationTokenSource(timeoutMs);
    var credPath = ".credentials/app-user-credentials";  //<-- In API refs ctor definead as FileDataStore(string folder, [bool fullPath = False]), credPath must be a folder name, not a file name as in your code
    var authTask = GoogleWebAuthorizationBroker.AuthorizeAsync(clientSecrets, Scopes, "someuniqueusername",
        credCts.Token, new FileDataStore(credPath, true));
    UserCredential credential = null;
    try
    {
        if (authTask.Wait(timeoutMs, credCts.Token))
        {
            credential = authTask.Result;
        }
        else
        {
            throw new OperationCanceledException("Auth time-out");
        }
    }
    catch (Exception ex)
    {
        Logger.Error(ex.Message);
		throw;
    }
    finally
    {
        credCts.Dispose();
        if (authTask.IsCanceled || authTask.IsCompleted || authTask.IsFaulted)
            authTask.Dispose();
    }
    
    
    // do some stuff...
            
