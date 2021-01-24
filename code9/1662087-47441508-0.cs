    [HttpGet]
    [Route("documents/{docid}")]
    public HttpResponseMessage Display(string docid) {
    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);
    var documents = reader.GetDocument(docid);
    if (documents != null && documents.Length == 1) {
        var document = documents[0];
        docid = document.docid;
        byte[] buffer = new byte[0];
        //generate pdf document
        MemoryStream memoryStream = new MemoryStream();
        MyPDFGenerator.New().PrintToStream(document, memoryStream);
        //get buffer
        buffer = memoryStream.ToArray();
        //content length for use in header
        var contentLength = buffer.Length;
        //200
        //successful
        var statuscode = HttpStatusCode.OK;
        response = Request.CreateResponse(statuscode);
        response.Content = new StreamContent(new MemoryStream(buffer));
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        response.Content.Headers.ContentLength = contentLength;
        ContentDispositionHeaderValue contentDisposition = null;
        if (ContentDispositionHeaderValue.TryParse("inline; filename=" + document.Name + ".pdf", out contentDisposition)) {
            response.Content.Headers.ContentDisposition = contentDisposition;
        }
    } else {
        var statuscode = HttpStatusCode.NotFound;
        var message = String.Format("Unable to find resource. Resource \"{0}\" may not exist.", docid);
        var responseData = responseDataFactory.CreateWithOnlyMetadata(statuscode, message);
        response = Request.CreateResponse((HttpStatusCode)responseData.meta.code, responseData);
    }
    return response;
}
