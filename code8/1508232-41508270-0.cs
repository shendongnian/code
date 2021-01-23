    private void FinishWebRequest(IAsyncResult result)
    {
        var request = (HttpWebRequest)result.AsyncState;
        var response = request.EndGetResponse(result);
        response.BeginGetResponseStream(this.FinishGetResponseStream, response);
    }
    private void FinishGetResponseStream(IAsyncResult result)
    {
        using (var response = (HttpWebResponse)result.AsyncState)
        using (var responseStream = response.EndGetResponseStream(result))
        {
            var xdoc = XDocument.Load(responseStream);
            ...
        }
    }
