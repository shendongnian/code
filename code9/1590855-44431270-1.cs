    protected virtual void Log(HttpResponseMessage response)
    {
        // Use any log/trace engine here, this example uses Debug
        Debug.WriteLine($"Response of the API Call [{response.RequestMessage.Method}] {response.RequestMessage.RequestUri}: {response.StatusCode} {FormatResponse(response)}");
    }
    private static string FormatResponse(HttpResponseMessage response)
    {
        var result = new StringBuilder();
        result.AppendLine();
        result.AppendLine("Original request:");
        result.AppendLine(FormatHttpMessage(response.RequestMessage.Headers, response.RequestMessage.Content));
        result.AppendLine();
        result.AppendLine("Obtained response:");
        result.AppendLine(FormatHttpMessage(response.Headers, response.Content));
    }
    private static string FormatHttpMessage(HttpHeaders headers, HttpContent content)
    {
        var result = new StringBuilder();
        var headersString = headers.ToString();
        if (!string.IsNullOrWhiteSpace(headersString))
        {
            result.AppendLine("Headers:");
            result.AppendLine(headersString);
            result.AppendLine();
        }
        if (content != null)
        {
            result.AppendLine("Content:");
            result.AppendLine(content.ReadAsStringAsync().Result);
        }
        return result.ToString();
    }
