    using (var responseMessage = await _httpClient.SendAsync(
        requestMessage, HttpCompletionOption.ResponseHeadersRead, context.RequestAborted))
    {
        context.Response.StatusCode = (int)responseMessage.StatusCode;
        foreach (var header in responseMessage.Headers)
        {
            context.Response.Headers[header.Key] = header.Value.ToArray();
        }
        foreach (var header in responseMessage.Content.Headers)
        {
            context.Response.Headers[header.Key] = header.Value.ToArray();
        }
        // SendAsync removes chunking from the response. This removes the header so it doesn't expect a chunked response.
        context.Response.Headers.Remove("transfer-encoding");
        await responseMessage.Content.CopyToAsync(context.Response.Body);
    }
