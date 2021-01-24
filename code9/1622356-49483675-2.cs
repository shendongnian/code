    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
    var stream = new FileStream(docDestination, FileMode.Open,FileAccess.Read);
    result.Content = new StreamContent(stream);
    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
    {
        FileName = "document.docx"
    };
    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.wordprocessingml.document"); 
    return result;
