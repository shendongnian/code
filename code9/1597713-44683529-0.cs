    try 
    {
        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                                    new[] { DriveService.Scope.Drive,                                  
                                            DriveService.Scope.DriveFile },
                                    "user",
                                    CancellationToken.None,
                                    new FileDataStore(credPath, true)).Result;
    }
    catch (AggregateException ex)
    {
        WriteLine(ex.Message + " Error Details: " + ex.InnerException);
    }
