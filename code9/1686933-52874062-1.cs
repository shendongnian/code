            [HttpPost]
            public ActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
            {                  
                if (upload.Length <= 0 ) return null;
                if (!upload.IsImage())
                {
                    var NotImageMessage = "please choose a picture";
                    dynamic NotImage = JsonConvert.DeserializeObject("{ 'uploaded': 0, 'error': { 'message': \"" + NotImageMessage + "\"}}");
                    return Json(NotImage);
                }
    
                var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
    
                Image image = Image.FromStream(upload.OpenReadStream());
                int width = image.Width;
                int height = image.Height;
                if ((width > 750) || (height > 500))
                {
                    var DimensionErrorMessage = "Custom Message for error"
                    dynamic stuff = JsonConvert.DeserializeObject("{ 'uploaded': 0, 'error': { 'message': \"" + DimensionErrorMessage + "\"}}");
                    return Json(stuff);
                }
    
                if (upload.Length > 500 * 1024)
                {
                    var LengthErrorMessage = "Custom Message for error";
                    dynamic stuff = JsonConvert.DeserializeObject("{ 'uploaded': 0, 'error': { 'message': \"" + LengthErrorMessage + "\"}}");
                    return Json(stuff);                
                }
    
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/images/CKEditorImages",
                    fileName);
    
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    upload.CopyTo(stream);
    
                }
    
                var url = $"{"/images/CKEditorImages/"}{fileName}";
                var successMessage = "image is uploaded successfully";
                dynamic success = JsonConvert.DeserializeObject("{ 'uploaded': 1,'fileName': \"" + fileName + "\",'url': \"" + url + "\", 'error': { 'message': \"" + successMessage + "\"}}");
                return Json(success);
            }
