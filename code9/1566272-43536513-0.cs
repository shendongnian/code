        public ActionResult Registration(Employee Emp)
        {
            HttpPostedFileBase image = Request.Files["Image"];
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/Upload"),
                                    Path.GetFileName(image.FileName + Guid.NewGuid().ToString("N")));
                    image.SaveAs(path);
                    //now save your entity in database `path` is the address of your file
                    //var empolyee = new  Employee { Images = path };
                }
            }
            return View();
        }
