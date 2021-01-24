    public class LoggingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                StoreResponse(response);
                return response;
            });
        }
       
        private void StoreResponse(HttpResponseMessage response)
        {
            var request = response.RequestMessage;
            (response.Content ?? new StringContent("")).ReadAsStringAsync().ContinueWith(x =>
            {
                var ctx = request.Properties["MS_HttpContext"] as HttpContextWrapper;
                if (request.Properties.ContainsKey("responseJson"))
                {
                    request.Properties["responsejson"] = x.Result;
                }
                else
                {
                    request.Properties.Add("responsejson", x.Result);
                }
            });
        }
    }
