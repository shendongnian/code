    public ActionResult CreateSiteLogo(SiteSettingsAPIModel siteSetting, HttpPostedFileBase logo)
        {
            //Getting the file path
            string path = Server.MapPath(logo.FileName);
            //getting the file name
            string filename = System.IO.Path.GetFileName(logo.FileName);
            using (var binaryReader = new BinaryReader(suitefile.InputStream))
            {
                fileContent = binaryReader.ReadBytes(suitefile.ContentLength);
            }
            siteSetting.SiteLogo = fileContent;
            return View();
        }
