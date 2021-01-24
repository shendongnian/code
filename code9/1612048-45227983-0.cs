    [HttpPost]
    public async Task<IActionResult> Index(ICollection<IFormFile> files) {
        var uploads = Path.Combine(_environment.WebRootPath, "UploadedFiles/Archives");
        foreach (var file in files) {
            if (file.Length > 0) {
                using (var fileStream = new FileStream(Path.Combine(uploads, "<My file name here>"), FileMode.Create)) {
                    await file.CopyToAsync(fileStream);
                }
            }
        }
        return View();
    }
