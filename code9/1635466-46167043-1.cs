    if (filename != "") {
        var fs = System.IO.File.OpenRead(filename);
        var response = Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StreamContent(fs);
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        return response;
    }
    return response;
