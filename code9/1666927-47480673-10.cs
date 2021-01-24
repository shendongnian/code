    public ActionResult UploadFile()
    {
       var list= ctx.Photos
                    .Select(x=>new ProfileImageVm { FileName=x.Url + x.Extension ,
                                                    CreatedTime = x.Timestamp })
                    .ToList();
       return View(list);
    }
