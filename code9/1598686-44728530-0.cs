    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveDocument(IList<IFormFile> files, 
    HomeViewModel model)
    {            
       foreach (IFormFile file in files)
        {
           string name =   
           ContentDispositionHeaderValue.Parse(file.ContentDisposition)
           .FileName.Trim('"');
           var filename = this.EnsureCorrectFilename(name);
           using (FileStream output = System.IO.File.Create(this.GetPathAndFilename(filename)))
                    await source.CopyToAsync(output);
                
        }
            //...maybe save to db and return somewhere
    }
    private string EnsureCorrectFilename(string filename)
       {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);
            return filename;
       }
    private string GetPathAndFilename(string filename)
       {           
            return _env.ContentRootPath + "\\Documents\\" + filename;
       }
