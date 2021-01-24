    //1. Set empty parameter list in action then neither serializator nor model binder are not invoked.
    public async Task<ContentResult> ProxyAction(/*empty parameter list*/)
    {
        var newUrl = @"https://stackoverflow.com";
        var data = this.Request.Body;
        using (var client = new HttpClient())
        {
            //2. Read request body from input stream.
            var reader = new StreamReader(data);
            var json = reader.ReadToEnd();
            using (var content = new StringContent(json))
            {
                //3. Set correct content type
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(this.Request.ContentType);
                //4. Post request to inner service
                var response = await client.PostAsync(newUrl, content);
                //5. Read response without deserialization
                var innerResponse = await response.Content.ReadAsStringAsync();
                var contentType = response.Content.Headers.ContentType.ToString();
                var statusCode = response.StatusCode;
                //6. Return inner response without serialization
                var outerResponse = this.Content(innerResponse, contentType);
                outerResponse.StatusCode = (int)statusCode;
                return outerResponse;
            }
        }
    }
