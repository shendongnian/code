    localFilePath = "file path";
    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
    response.Content = new StreamContent(new FileStream(filepath, FileMode.Open, FileAccess.Read));
    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
    response.Content.Headers.ContentDisposition.FileName = fileName;
    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf or set your content type");
    return response;
