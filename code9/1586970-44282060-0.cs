    public IHttpActionResult PostCellInfo(IList<IFormFile> files)
    {
         foreach (var file in files) {
            if (file.Length > 0) {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {  
                   var fileContent = reader.ReadToEnd();
                }
            }
         }
    }
