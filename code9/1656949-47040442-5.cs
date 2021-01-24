    public class ErrorMessageHandler : DelegatingHandler {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken) {
            var response = await base.SendAsync(request, cancellationToken);
            if (response.IsSuccessStatusCode)
                return response;
            // here, can also check if 404
            request.Properties.Remove(HttpPropertyKeys.NoRouteMatched);
            var formatter = new JsonMediaTypeFormatter();
            var errorResponse = request.CreateResponse(response.StatusCode, "Oops!", formatter);
            return errorResponse;
        }
    }
