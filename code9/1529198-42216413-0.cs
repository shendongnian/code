    //...other code removed for brevity
    using (var form = new MultipartFormDataContent()) {
        var stringContent = new StringContent("fileToUpload");
        form.Add(stringContent, "fileToUpload");
        var streamContent = new StreamContent(file.InputStream);
        streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType);
        streamContent.Headers.ContentLength = file.ContentLength;
        streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") {
            Name = "fileToUpload",
            FileName = file.FileName
        };
        form.Add(streamContent);
        using (var httpClient = new HttpClient()) {
            var response = await httpClient.PostAsync(baseUri, form);
            //...other code removed for brevity
        }
    }
