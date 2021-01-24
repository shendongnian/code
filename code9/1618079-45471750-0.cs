        [HttpPost]
        public ActionResult Upload(newModel model, HttpPostedFileBase file)
        {
            // Check the file is valid.
            if (file == null || file.ContentLength == 0 || string.IsNullOrEmpty(file.FileName))
                ModelState.AddModelError("fileUpload", "Invalid file uploaded.");
            // Access model properties as you wish, like this:
            int phoneID = model.PhoneId;
            return null;
        }
