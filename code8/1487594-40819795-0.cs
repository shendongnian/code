    var task = Task.Run(() =>
    {
       for (int i = 1; i < 6; i++)
       {
           // this exception is associated with cTokenSource.Token
           cTokenSource.Token.ThrowIfCancellationRequested();
           DoPrint(i, cTokenSource.Token);
       }
    }, cTokenSource.Token); // and this is the same token you pass when creating a task
    
