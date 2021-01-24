    public JsonResult UploadImage()
            {
                string fileName = Request.Headers["X-File-Name"];
                string fileType = Request.Headers["X-File-Type"];
                int fileSize = Convert.ToInt32(Request.Headers["X-File-Size"]);
    
                System.IO.Stream fileContent = Request.InputStream;
                System.IO.FileStream fileStream = System.IO.File.Create(Server.MapPath("~/UploadImg/" + fileName));
                fileContent.Seek(0, System.IO.SeekOrigin.Begin);
    
                //Copying file's content to FileStream
                fileContent.CopyTo(fileStream);
                fileStream.Dispose();
    
                string FileName = Server.MapPath("~/UploadImg/" + fileName);
    
                //Here you can code for insert in database
                
                return Json(FileName);
            }
