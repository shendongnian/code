    public static class RestSharpExtensions
    {
        public static RestResponse Execute(this IRestClient client, IRestRequest request)
        {
            var taskCompletion = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
            return (RestResponse)(taskCompletion.Task.Result);
        }
    }
now I can use use it as var response = restClient.Execute(request);
