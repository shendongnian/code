    result = Request.CreateResponse(HttpStatusCode.OK);
    result.Content = new ByteArrayContent(data);
    result.Content.Headers.Add("Content-Type", "application/pdf");
    result.Content.Headers.ContentDisposition =
                            new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                            {
                                FileName = "FileNameHere"
                            };
    
    return result;
