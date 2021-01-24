    [HttpPost]
    public async Task<JsonResult> QuestionPhotoPost(IFormFile FileUpload, string QuestionText, Guid? QuestionId)
    {
        string TempFileName = string.Empty;
        var directiveToUpload = Path.Combine(_environment.WebRootPath, "images\\UploadFile");
        var http = HttpRequestExtensions.GetUri(Request);
        QuestionViewModel model = new QuestionViewModel();
        try
        {
            
            if (FileUpload != null)
            {
                TempFileName = FileUpload.FileName;
                await CheckFileFromFrontEndAsync();
            }
            
        }
        catch (Exception exception)
        {
            
        }
        async Task CheckFileFromFrontEndsync()
        {
            if (FileUpload != null)
            {
                if (!System.IO.Directory.Exists(directiveToUpload))
                {
                    System.IO.Directory.CreateDirectory(directiveToUpload);
                }
                if (System.IO.File.Exists(string.Format("{0}\\{1}\\{2}", _environment.WebRootPath, "images\\UploadFile", FileUpload.FileName)))
                {
                    TempFileName = Guid.NewGuid().ToString() + FileUpload.FileName;
                }
                model.PictureUrl = string.Format("{0}://{1}/{2}/{3}/{4}", http.Scheme, http.Authority, "images", "UploadFile", TempFileName);
                await SaveFileToServerAsync(TempFileName);
            }
        }
        async Task SaveFileToServerAsync(string FileName)
        {
            if (FileUpload.Length > 0)
            {
                using (var stream = new FileStream(Path.Combine(directiveToUpload, FileName), FileMode.Create))
                {
                    await FileUpload.CopyToAsync(stream);
                }
            }
        }
        return Json(genericResponseObject);
    }
