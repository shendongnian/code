    [HttpPost]
        public async Task<IActionResult> UploadFileImage(ICollection<IFormFile> files)
        {
            string file_name = "the file name";
            var uploads = Path.Combine(_environment.WebRootPath, "uploads/Image");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file_name ), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return View();
        }
