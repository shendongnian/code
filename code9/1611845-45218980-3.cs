    [HttpPost]
    public ActionResult UploadExcel()
    {
        if (Request.Files.Count > 0)
        {
            try
            {
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    // Do somethig with file
                }
                return Json("File Uploaded Successfully!");
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }
        else
        {
            return Json("No files selected.");
        }
    }
