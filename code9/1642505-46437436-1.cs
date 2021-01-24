    public IActionResult Index()
    {
        //Please note that if no form data is posted
        // HttpContext.Request.Form will throw an exception
        if (HttpContext.Request.Form.Files["FileName"] != null) {
            var file = HttpContext.Request.Form.Files["FileName"];
            using (FileStream fs = new FileStream("Your Path", FileMode.CreateNew, FileAccess.Write, FileShare.Write)) {
                file.CopyTo(fs);
            }
        }
        return View();
    }
