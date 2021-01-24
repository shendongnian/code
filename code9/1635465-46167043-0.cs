    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);
    string filename = "somefilename.pdf";
    if (filename != "") {
        response = Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StreamContent(File.OpenRead(filename));
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        response.Content.Headers.ContentLength = buffer.Length;
        ContentDispositionHeaderValue contentDisposition = null;
        if (ContentDispositionHeaderValue.TryParse("inline; filename=" + filename, out contentDisposition))
        {
            response.Content.Headers.ContentDisposition = contentDisposition;
        }
    }
    return response;
