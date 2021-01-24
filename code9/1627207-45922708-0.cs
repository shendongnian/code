    var result = new HttpResponseMessage(HttpStatusCode.OK)
    {
         Content = new ByteArrayContent(outStream.GetBuffer(),0,(int)outStream.Length)
    };
    result.Content.Headers.ContentDisposition =
             new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
             {
                  FileName = fname
             };
    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
    return result;
