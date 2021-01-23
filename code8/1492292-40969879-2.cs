        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadIcon(HttpPostedFileBase file, string returnAction)
        {
            if (file != null && file.ContentLength > 0)
            {
                //Upload Image
            }
            else
                TempData["TempMessage"] = "Please Select Picture! (jpg/png)";
            return RedirectToAction(returnAction);
        }
