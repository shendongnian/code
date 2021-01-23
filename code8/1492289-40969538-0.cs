    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult UploadIcon(HttpPostedFileBase file, int returnId)
    {
        if (file != null && file.ContentLength > 0)
        {
            //Upload Image
        }
        else
            TempData["TempMessage"] = "Please Select Picture! (jpg/png)";
        if(returnId == 1) 
           return RedirectToAction("Page1");
        //and so on..
    }
