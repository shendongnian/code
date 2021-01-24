    private static bool CheckResponseStatusCodeFailed<TBody, THeader>(
                AzureOperationResponse<TBody, THeader> initialResponse)
            {
                var statusCode = initialResponse.Response.StatusCode;
                var method = initialResponse.Request.Method;
                if (statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.Accepted ||
                    (statusCode == HttpStatusCode.Created && method == HttpMethod.Put) ||
                    (statusCode == HttpStatusCode.NoContent && (method == HttpMethod.Delete || method == HttpMethod.Post)))
                {
                    return false;
                }
                return true;
        }
