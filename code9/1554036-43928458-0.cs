    var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
    var content new StreamContent(stream);
    content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline");
    content.Headers.ContentDisposition.FileName = fileName;
    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
    var response = Request.CreateResponse(HttpStatusCode.OK);
    response.Content = content;
    return response;
