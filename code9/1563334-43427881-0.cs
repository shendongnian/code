        [HttpPost]
        public ActionResult GetImageRequest()
        {
            HttpPostedFileBase hpf = Request.Files["image"];
            if (hpf != null && hpf.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(hpf.InputStream))
                {
                    byte[] imageFile = 
                       binaryReader.ReadBytes(hpf.ContentLength);
                }
                UploadImage(imageFile);                
            }
            return RedirectToAction("Index");
        }
