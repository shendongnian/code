        [HttpPost]
        [Route("api/StoreImage")]
        public string StoreImage(PhotoUploadRequest request)
        {
            var buffer = Convert.FromBase64String(request.image);
            HttpPostedFileBase objFile = (HttpPostedFileBase)new MemoryPostedFile(buffer);
            //Do whatever you want with filename and its binaray data.
            try
            {
                if (objFile != null && objFile.ContentLength > 0)
                {
                    string path = "Set your desired path and file name";
                    objFile.SaveAs(path);
                    //Don't Forget to save path to DB
                }
            }
            catch (Exception ex)
            {
               //HANDLE EXCEPTION
            }
          
            return "OK";
        }
