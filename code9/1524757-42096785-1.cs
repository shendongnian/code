    private static Task<HttpStatusCode> GetStatusCodeAsync(object url, CancellationToken token)
    {
        try
        {
            // Your HttpClient code
            // ...
            // (pass token on to methods that support it)
            // ...
            return httpStatusCode;
        }
        catch (Exception e)
        {
            // Don't rethrow if you handle everything here
            return HttpStatusCode.Unused; // (or whatever)
        }
    }
