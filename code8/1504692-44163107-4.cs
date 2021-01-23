    public static class RestClientExtensions
    {
    	public static async Task<RestResponse> ExecuteAsync(this RestClient client, RestRequest request)
    	{
    		TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
    		_ = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
    		return (RestResponse)(await taskCompletion.Task);
    	}
    }
