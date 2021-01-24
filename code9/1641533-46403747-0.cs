        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase postedFile)
        {
            int compId = Convert.ToInt32(Session["compID"]);
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var filename = compId.ToString() + Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(path + filename);
                ViewBag.Message = "File uploaded successfully.";
            }
            return RedirectToAction("AddCompany");
        }
