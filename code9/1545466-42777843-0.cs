    results.ContinueWith(finishedTask =>
    {
        var param1ApiResult = param1Task.Result; 
        var param2ApiResult = param2Task.Result;
    });
