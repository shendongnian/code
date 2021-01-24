        [HttpPost]
        public ActionResult SaveProfileImage(string GenericID)
        {
            try
            {
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                    HttpPostedFileBase filebase = new HttpPostedFileWrapper(pic);
                    var fileName = docId.ToString() + ".png";
                    var path = Path.Combine(Server.MapPath("~/UploadGenericImage/"), fileName);
                    filebase.SaveAs(path);
                    //return Json("File Saved Successfully.");
                    return Json(new { data = true});
                }
                else { return Json("No File Saved."); }
            }
            catch (Exception ex) { return Json("Error While Saving."); }
        }
