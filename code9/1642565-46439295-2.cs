    public ActionResult Create(ModelNameVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        // Initialize a new instance of your data model and map values from the view model
        ModelName data = new ModelName
        {
            PinNumbers = model.PinNumbers
        };
        if (model.SerialAttachment != null && model.SerialAttachment.ContentLength > 0)
        {
            string fileName = Path.GetFileName(model.SerialAttachment.FileName);
            ..... 
            model.SerialAttachment.SaveAs(path);
            data.SerialAttachment = path
        }
        .... // repeat for CountryAttachment and OtherAttachment 
        db.model.Add(data);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
