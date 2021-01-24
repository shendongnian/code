                [HttpGet]
                [Route("FileServe")]
                [Authorize(Roles = "Admin,SuperAdmin,Contractor")]
                public async Task<HttpResponseMessage> GetFileAsync(int FileID) //<-- If your method returns Task have it be named with Async in it
                {
                    using (var repo = new MBHDocRepository())
                    {
                        var file = await repo.GetSpecificFile(FileID);
                        if (file == null)
                        {
                          throw new HttpResponseException(HttpStatusCode.BadRequest);
                        }
    
                var stream = File.Open(file.PathLocator, FileMode.Open);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.FileType);
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName=Path.GetFileName(file.PathLocator)};
                return response;
                    }
                }
