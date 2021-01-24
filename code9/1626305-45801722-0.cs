    [HttpGet]
            [Route("FileServe")]
            [Authorize(Roles = "Admin,SuperAdmin,Contractor")]
            public async Task<HttpResponseMessage> GetFileAsync() //<-- If your method returns Task have it be named with Async in it
            {
                var stream = File.Open(@"C:\Users\Bailey Miller\Downloads\razer-paper.png", FileMode.Open);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName=Path.GetFileName(stream.Name)};
                return response;
            }
