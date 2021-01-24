    private Task SendResponseMessageAsync(HttpRequestMessage request, HttpResponseMessage response,
            IOwinResponse owinResponse, CancellationToken cancellationToken)
        {
            owinResponse.StatusCode = (int)response.StatusCode;
            owinResponse.ReasonPhrase = response.ReasonPhrase;
            // Copy non-content headers
            IDictionary<string, string[]> responseHeaders = owinResponse.Headers;
            foreach (KeyValuePair<string, IEnumerable<string>> header in response.Headers)
            {
                responseHeaders[header.Key] = header.Value.AsArray();
            }
            HttpContent responseContent = response.Content;
            if (responseContent == null)
            {
                SetHeadersForEmptyResponse(responseHeaders);
                return TaskHelpers.Completed();
            }
            else
            {
                // Copy content headers
                foreach (KeyValuePair<string, IEnumerable<string>> contentHeader in responseContent.Headers)
                {
                    responseHeaders[contentHeader.Key] = contentHeader.Value.AsArray();
                }
                // Copy body
                return SendResponseContentAsync(request, response, owinResponse, cancellationToken);
            }
        }
