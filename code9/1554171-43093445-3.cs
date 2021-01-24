     //Main View
        public ActionResult List()
        {
                return View();
        }
    //Partial View
    public Action GalleryImages(int PageNo)
    {
        int PageSize = 30;
         var model = db.Photo.Select(m => new PhotoViewModel
        {
            Id = m.Id,
            Name = m.Name,
            StatusId = m.StatusId,
            SubmitDate = m.SubmitDate,
            FileAttachments = m.FileAttachments,
            SubmitNo = m.SubmitNo
        }).Skip(PageNo*PageSize).Take(PageSize).ToArray();
    
        return PartialView("_galleryImages", model);
    }
   
