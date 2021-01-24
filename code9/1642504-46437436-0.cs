    public IActionResult Index()
    {
        if (HttpContext.Request.Form.Files != null) {
            var file = HttpContext.Request.Form.Files["FileName"];
            // You can also double check if the file is present (file != null)
            using (FileStream fs = new FileStream("Your Path", FileMode.CreateNew, FileAccess.Write, FileShare.Write)) {
                    file.CopyTo(fs);
                }
        }
        return View();
    }
