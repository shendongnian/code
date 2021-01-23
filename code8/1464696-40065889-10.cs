    public HttpResponseMessage GetAttachment(Guid noteGuid)
    {
        byte[] content = Convert.FromBase64String(retrievedAnnotation.DocumentBody);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new ByteArrayContent(content);
        response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        response.Content.Headers.ContentDisposition.FileName = "fileName.txt";
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
    
        return response;
    }
