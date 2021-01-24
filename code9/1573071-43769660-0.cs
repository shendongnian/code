    if (context != null && context.Exception != null)
    {
        HttpContent requestContent = new HttpContent();
        request.Content.CopyToAsync(requestContent);
        ExceptionTelemetry telemetry = new ExceptionTelemetry(context.Exception);
        // the requestBody is always empty because the stream is non-rewinadable?
        string requestBody = requestContent.ReadAsStringAsync().Result;
        telemetry.Properties.Add("Request Body", requestBody);
        Logger.LogException(context.Exception);
    }
