    [HttpPost]
    [ValidateAntiForgeryToken]
     public ActionResult Registration(Users user)
            {
               if (ModelState.IsValid)
              {
                UploadUserAvatar(user.uploadFile);
                return View();
              }       
            }
      protected void UploadUserAvatar(HttpPostedFileBase image)
            {
                HttpPostedFileBase file = image;
                if (file != null)
                {
                    if (!Directory.Exists(Server.MapPath("~/Content/Images")))
                        Directory.CreateDirectory(Server.MapPath("~/Content/Images"));
                    string _fileName = Path.GetExtension(file.FileName);
                    string _path = System.IO.Path.Combine(Server.MapPath("~/Content/Images/"), _fileName);
                    file.SaveAs(_path);
                    
                }
          }
