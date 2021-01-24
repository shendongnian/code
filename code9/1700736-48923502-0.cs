      [Route("api/<Controller name>/Files/GetFile")]
        public HttpResponseMessage GetFile(string fileName)
        {
            string filePath = <Path to the wanted file on the server - same file system >
            if (!File.Exists(filePath))
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(filePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = Path.GetFileName(filePath);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            return response;
        }
   
    
