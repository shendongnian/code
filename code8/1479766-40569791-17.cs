    [HttpPost]
    public ActionResult Upload(FileUploadModel model)
    {
        //Validate
        if (ModelState.IsValid)
        {
            //Use your fileProvider here to upload the file
            var content = new byte[model.PostedFile.ContentLength];
            model.PostedFile.InputStream.Write(content, 0, content.Length);
            var result = fileProvider.UploadFile(content, model.PostedFile.FileName);
            if (result.Success)
            {
                //TODO: Notify the user about operation success
    
                return RedirectToAction("Index", "Upload");
            }
        }
    
        //
        return View(model);
    }
