    public async Task<IHttpActionResult> Post()
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
                }
    
                //load in a memory stream or in azure blob storage
                var uploadFolder = "~/App_Data/FileUploads"; // to demonstrate the upload so please don't comment about where I'm saving the file, don't recommend this under no circumstance
                var root = HttpContext.Current.Server.MapPath(uploadFolder);
                Directory.CreateDirectory(root);
                var provider =  new MultipartFormDataStreamProvider(root);
                var result = await Request.Content.ReadAsMultipartAsync(provider);
    
                if (result.FileData.FirstOrDefault() == null)
                {
                    return BadRequest("No import file was attached");
                }
               
                var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);
    
                var model = result.FormData["model"];
    
                if (model == null)
                {
                    return BadRequest("Model is missing");
                }
    
                var parameters = JsonConvert.DeserializeObject<Coords>(model);
    
                var byteArray = File.ReadAllBytes(uploadedFileInfo.FullName);
               //..process the bytes
               //..process json passed in headers
    }
