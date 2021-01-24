        [HttpGet]
        public async Task<HttpResponseMessage> Get(string fileHash)
        {
            //read file 
            byte[] fileData = await _deviceFileApiService.GetFileData(fileHash);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(fileData)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileResource.FileName
            };
            return response;
        }
