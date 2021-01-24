    HttpResponseMessage finalResponse = Request.CreateResponse();
    
     finalResponse.Headers.AcceptRanges.Add("bytes");
        finalResponse.StatusCode = HttpStatusCode.OK;
        finalResponse.Content = new StreamContent(response);
        finalResponse.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("render");
        finalResponse.Content.Headers.ContentDisposition.FileName = "fileName";
        finalResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("<set media type>");
        finalResponse.Content.Headers.ContentLength = response .Length;
    
    return finalResponse;
