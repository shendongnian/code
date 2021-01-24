    /// <summary>
    /// Calls a JSON/REST POST service.
    /// </summary>
    /// <typeparam name="TValue">Type of to be sent value.</typeparam>
    /// <param name="loadPackage">Mandatory. The package the post call shall carry.</param>
    /// <param name="requestUri">Mandatory. URI which shall be called.</param>
    /// <returns>Returns the plain service response.</returns>
    public async Task<HttpResponseMessage> CallPostServicePlainAsync<TValue>(
        TValue loadPackage,
        string requestUri)
    {
        using (var httpClient = CreateHttpClient()) // or just `new HttpClient()` plus magic
        {
            bool isStream = typeof(TValue) == typeof(Stream);
            bool isMultipleStreams = typeof(TValue) == typeof(Stream[]);
            if (isStream || isMultipleStreams)
            {
                var message = new HttpRequestMessage();
                message.Method = HttpMethod.Post; // that's what makes it a POST :-)
                var content = new MultipartFormDataContent();
                if (isStream) // single stream
                    content.Add(new StreamContent(loadPackage as Stream));
                else if (isMultipleStreams) // this is an array of streams
                    foreach (Stream stream in loadPackage as Stream[])
                        content.Add(new StreamContent(stream));
                else // oops
                    throw new NotImplementedException("incorrect load package.");
                message.Content = content;
                message.RequestUri = new Uri(requestUri);
                return await httpClient.SendAsync(message).ConfigureAwait(false);
            } else {
                // standard serializable content (not streams)
                ...
            }
        }
    }
