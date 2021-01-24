    public void PostFile(IFormFile file)
    {          
        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
        if (file.Length > 0)
        {
            var filePath = Path.Combine(uploads, file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(fileStream);
            }
        }
    }
