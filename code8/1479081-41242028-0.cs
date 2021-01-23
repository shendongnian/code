                [HttpPost()]
                public async Task<IHttpActionResult> UploadFile()
                {
                    if (!Request.Content.IsMimeMultipartContent())
                        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        
                    try
                    {
                        MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();
        
                        await Request.Content.ReadAsMultipartAsync(provider);
        
                        if (provider.Contents != null && provider.Contents.Count == 0)
                        {
                            return BadRequest("No files provided.");
                        }
        
                        foreach (HttpContent file in provider.Contents)
                        {
                            string filename = file.Headers.ContentDisposition.FileName.Trim('\"');
        
                            byte[] buffer = await file.ReadAsByteArrayAsync();
        
                            using (MemoryStream stream = new MemoryStream(buffer))
                            {
                               // save the file whereever you want 
        
                            }
                        }
        
                        return Ok("files Uploded");
                    }
                    catch (Exception ex)
                    {
                        return InternalServerError(ex);
                    }
                }
