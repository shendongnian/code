    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
    using (var stream = new MemoryStream(excelData))
    {
        result.Content = new StreamContent(stream);
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        {
            FileName = "Data.xls"
        };
    }
    return ResponseMessage(result);
