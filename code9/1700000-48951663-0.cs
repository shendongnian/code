        public async Task<IHttpActionResult> PostUploadFile()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                NameValueCollection formdata = provider.FormData;
            
                JobPosition jobPosition = new JobPosition()
                {
                    Id = formdata["Id"],
                    Title = bool.Parse(formdata["Title"])
                };
                foreach (MultipartFileData file in provider.FileData)
                {
                    var fileName = file.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
                    byte[] documentData = File.ReadAllBytes(file.LocalFileName);
					/// Save document documentData to DB or where ever
					/// --- TODO
                }
                return Ok(jobPosition);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
