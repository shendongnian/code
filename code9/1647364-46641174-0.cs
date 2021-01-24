    public class CustomMessageHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Call the inner handler.
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest &&
                request.RequestUri.ToString().Contains("getmethod"))
            {
                HttpError error = null;
                if (response.TryGetContentValue(out error))
                {
                    // Modify the message details
                    error.MessageDetail = "Something customized.";
                }
            }
            return response;
        }
    }
