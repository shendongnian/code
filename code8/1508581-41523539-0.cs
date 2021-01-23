    public override RestRequestAsyncHandle ExecuteAsyncPost(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod)
    {
      HttpWebRequest webRequest = /* Construct webRequest from request/httpMethod */
      var result = new RestRequestAsyncHandle(webRequest);
      DoWebRequest(webRequest, result, callback);
    }
    private async void DoWebRequest(HttpWebRequest webRequest, RestRequestAsyncHandle result, Action<IRestResponse, RestRequestAsyncHandle> callback)
    {
      IRestResponse response;
      try
      {
        var webResponse = await webRequest.GetResponseAsync().ConfigureAwait(false);
        response = /* Construct an IRestResponse using webResponse */
      }
      catch (Exception ex)
      {
        response = /* Construct an IRestResponse with error information */
      }
      callback(response, result);
    }
