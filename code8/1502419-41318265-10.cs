    public ACtionResult Edit(EditBusinessVm model)
    {
      // purposefully omitting null checks/model validations code here
       //get existing entity
       var b=db.Businesses.FirstOrDefault(f=>f.BusinessId==model.Id);
      //update the properties from the posted view model
       b.Name = model.Name;
       if(model.BioPhoto!=null)  // user selected a new photo.
         b.BioPhoto = GetByteArray(model.BioPhoto);
       // to do : Set other properties as well.
       db.Entry(business).State = EntityState.Modified;
       db.SaveChanges();
       return RedirectToAction("Index");
       
    }
    private byte[] GetByteArray(HttpPostedFileBase file)
    {
       MemoryStream target = new MemoryStream();
       file.InputStream.CopyTo(target);
       return target.ToArray();      
    }
