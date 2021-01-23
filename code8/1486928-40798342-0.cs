    public void UploadFiles(int clientContactId)
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }        
                var jsonContent = Request.Content.ReadAsStringAsync().Result;
                JObject jObject = JObject.Parse(jsonContent);
                var filesToDelete = jObject["filesToDelete"];    
            }  
