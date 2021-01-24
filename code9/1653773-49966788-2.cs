      foreach (IFormFile source in files)
      {
        string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');
    
        filename = this.EnsureCorrectFilename(filename);
    
        using (FileStream output = System.IO.File.Create(this.GetPathAndFilename(filename)))
          await source.CopyToAsync(output);
      }
    
      return this.View();
    }
    
    private string EnsureCorrectFilename(string filename)
    {
      if (filename.Contains("\\"))
        filename = filename.Substring(filename.LastIndexOf("\\") + 1);
    
      return filename;
    }
    
    private string GetPathAndFilename(string filename)
    {
      return this.hostingEnvironment.WebRootPath + "\\uploads\\" + filename;
    }
