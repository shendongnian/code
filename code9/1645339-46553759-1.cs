    public ActionResult UploadFile(UploadFileViewModel model)
    {
        if (ModelState.IsValid)
        {
            //to do : Save model.Img
            return Json(new {status = "success", message = "Success!"});
        }
        else
        {
            var errorList = (from modelStateVal in ViewData.ModelState.Values from error 
                                in modelStateVal.Errors select error.ErrorMessage).ToList();
            return Json(new { status = "error", errorList = errorList });
        }
    }
