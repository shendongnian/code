    Task task = Task.Factory.StartNew(() =>
    {
        WebRequest request = WebRequest.Create("http://facebook.com");
        request.Timeout = 5000;
        HttpWebResponse response = (HttpWebResponse) request.GetResponse();
        
    });
    // Run this code after successfully completing the task...
    task.ContinueWith(t =>
    {
       websiteIsAvailable = true;
       //Some code...
    }, TaskContinuationOptions.OnlyOnRanToCompletion);
    // Run this code after task Failure...
    task.ContinueWith(t =>
    {
       websiteIsAvailable = false;
       //Some code...
    }, TaskContinuationOptions.OnlyOnFaulted);
