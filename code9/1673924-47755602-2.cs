    [HttpPost]
    public IActionResult Create(Product model, IFormFile img)
    {
        if (img != null)
        {
            model.Image = GetByteArrayFromImage(img);
            model.ImageSourceFileName = System.IO.Path.GetFileName(img.FileName);
            model.ImageContentType = img.ContentType;
        }
        _context.Products.Add(model);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    private byte[] GetByteArrayFromImage(IFormFile file)
    {
        using (var target = new MemoryStream())
        {
            file.CopyTo(target);
            return target.ToArray();
        }
    }
