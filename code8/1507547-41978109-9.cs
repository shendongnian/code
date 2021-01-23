    public class HttpErrorHandler : DelegatingHandler {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            var response = await base.SendAsync(request, cancellationToken);
            return NormalizeResponse(request, response);
        }
        private HttpResponseMessage NormalizeResponse(HttpRequestMessage request, HttpResponseMessage response) {
            object content;
            if (!response.IsSuccessStatusCode && response.TryGetContentValue(out content)) {
                var error = content as HttpError;
                if (error != null) {
                    
                    var unifiedModel = new {
                        error = error.Message,
                        error_description = (object)error.MessageDetail ?? error.ModelState
                    };
                    var newResponse = request.CreateResponse(response.StatusCode, unifiedModel);
                    foreach (var header in response.Headers) {
                        newResponse.Headers.Add(header.Key, header.Value);
                    }
                    return newResponse;
                }
            }
            return response;
        }
    }
