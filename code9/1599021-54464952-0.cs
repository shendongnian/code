     public async Task GetFile(CancellationToken cancellationToken)
        {
            var context = HttpContext;
            var _httpClient = StaticHttpClient.Instance;
            var requestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://localhost:44305/api/files/123"),
            };
            using (var responseMessage = await _httpClient.SendAsync(
    requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                Response.StatusCode = (int)responseMessage.StatusCode;
                foreach (var header in responseMessage.Headers)
                {
                    Response.Headers[header.Key] = header.Value.First();
                }
                foreach (var header in responseMessage.Content.Headers)
                {
                    Response.Headers[header.Key] = header.Value.First();
                }
                Response.Headers.Remove("transfer-encoding");
                Response.BinaryWrite(await responseMessage.Content.ReadAsByteArrayAsync());
                Response.Flush();
                Response.Close();
                context.ApplicationInstance.CompleteRequest();
            }
        }
