     [HttpPost]
        public JsonResult UploadAndSaveFile(string ToEmail, string CcEmail, string Subject, string Desc)
        {
            if (Request.Files.Count > 0)
            {
                //  Get all files from Request object  
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    byte[] fileContent = new byte[file.ContentLength];
                    file.InputStream.Read(fileContent, 0, Convert.ToInt32(file.ContentLength));
                    string Filename = file.FileName;
                    string extension = Path.GetExtension(file.FileName);
                }
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
