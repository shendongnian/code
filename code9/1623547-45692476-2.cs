    [HttpPost]
    public ActionResult Create(TripPicture model, HttpPostedFileBase ImageData)
    {
        if (ImageData != null)
        {
            model.TripId = 1;
            model.Image = this.ConvertToBytes(ImageData);
        }
    
        _unitOfWork.TripsRepository.Add(model);
        _unitOfWork.Commit();
    
        return View(model);
    }
