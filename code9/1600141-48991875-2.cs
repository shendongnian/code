    [HttpPost]
    [Route("/api/upload")]
    public async Task<IActionResult> Upload(IFormFile fileForController)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (fileForController == null) throw new Exception("File is null");
        if (fileForController.Length == 0) throw new Exception("File is empty");
        var theImage = new Image();
        var path = Path.Combine("~\\ClientApp\\app\\assets\\images\\", fileForController.FileName);
        theImage.Url = path + fileForController.FileName;
        theImage.Title = fileForController.Name + "_" + fileForController.FileName;
        theImage.Caption = fileForController.Name + " and then a Surprice Caption";
        using (Stream stream = fileForController.OpenReadStream())
        {
            using (var reader = new BinaryReader(stream))
            {
                var fileContent = reader.ReadBytes((int)fileForController.Length);
                theImage.ImageFileContent = fileContent;
                _context.Images.Add(theImage);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        return Ok(theImage);
    }
