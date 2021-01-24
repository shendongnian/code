    public class ResponseWrapper : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var response = await base.SendAsync(request, cancellationToken);
    
                if (request.RequestUri.ToString().Contains("swagger"))
                {
                    return response;
                }
    
                return BuildApiResponse(request, response);
            }
    
            private static HttpResponseMessage BuildApiResponse(HttpRequestMessage request, HttpResponseMessage response)
            {
                object content = null;
                string errorMessage = null;
                response.TryGetContentValue(out content);
                    
                if (!response.IsSuccessStatusCode)
                {
                    content = null;
                    var error = new HttpError(response.Content.ReadAsStringAsync().Result);              
                    var data = (JObject)JsonConvert.DeserializeObject(error.Message);
                    errorMessage = data["message"].Value<string>();
    
                    if (!string.IsNullOrEmpty(error.ExceptionMessage) && string.IsNullOrEmpty(errorMessage))
                    {
                        errorMessage = error.ExceptionMessage;
                    }
                }
    
                var newResponse = request.CreateResponse(response.StatusCode, new ApiResponse(response.StatusCode, content, errorMessage));
    
                foreach (var header in response.Headers)
                {
                    newResponse.Headers.Add(header.Key, header.Value);
                }
    
                return newResponse;
            }
        }
