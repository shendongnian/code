    public static class RestClientExtensions
    {
    	public static async Task<RestResponse> ExecuteAsync(this RestClient client, RestRequest request)
    	{
    		TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
    		RestRequestAsyncHandle handle = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
    		return (RestResponse)(await taskCompletion.Task);
    	}
    }
