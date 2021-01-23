    using (var zipStream = ....)
            {
                Test(zipStream);
            }
    public HttpResponseMessage Test(Stream zipStream)
        {
            var fileResponse = new HttpResponseMessage(HttpStatusCode.OK);
            fileResponse.Content = new StreamContent(zipStream);
            fileResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return fileResponse;
        }
