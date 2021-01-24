     public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic); 
                // file is uploaded
                file.SaveAs(path);
    
                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream()) 
                {
                     file.InputStream.CopyTo(ms);
                     byte[] array = ms.GetBuffer();
                }
    
            }
        // after successfully uploading redirect the user
        return RedirectToAction("actionname", "controller name");
    }
