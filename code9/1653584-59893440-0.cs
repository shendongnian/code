       [HttpPost("UploadSingleFile"), Route("[action]")]
        public async Task<IActionResult> UploadSingleFile([FromForm(Name = "file")] IFormFile file)
        {
          
    
            // Process uploaded files
    
            string folderName = "Uploads";
            string webRootPath = hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
    
            Repository.Models.File fileModel = new Repository.Models.File();
            fileModel.Name = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            fileModel.Path = $"{folderName}/{file.FileName}";
            fileModel.Size = file.Length;
            fileModel.Type = file.ContentType;
    
            string fullPath = Path.Combine(newPath, fileModel.Name);
    
            fileModel.Extension = Path.GetExtension(fullPath);
            fileModel.CreatedDate = Utility.Common.GetDate;
            fileModel.CreatedBy = 1;
    
            //fileModel save to db
    
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                //file.CopyTo(stream);
                await file.CopyToAsync(stream);
            }
     
            return Ok(new { count = 1, path = filePath });
        }
