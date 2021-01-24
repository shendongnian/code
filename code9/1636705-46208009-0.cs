    //...code removed for brevity
    var buffer = os.ToArray();
    var contentLength = buffer.Length;
    var statuscode = HttpStatusCode.OK;
    var response = Request.CreateResponse(statuscode);
    response.Content = new ByteArrayContent(buffer);
    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
    response.Content.Headers.ContentLength = contentLength;
    ContentDispositionHeaderValue contentDisposition = null;
    if (ContentDispositionHeaderValue.TryParse("inline; filename=" + "testPDF.pdf", out contentDisposition)) {
        response.Content.Headers.ContentDisposition = contentDisposition;
    }
    return response;
