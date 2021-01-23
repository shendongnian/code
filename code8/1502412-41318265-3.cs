    public ACtionResult Edit(EditBusinessVm model)
    {
      // purposefully omitting null checks/model validations code here
       //get existing entity
       var b=db.Businesses.FirstOrDefault(f=>f.BusinessId==model.Id);
      //update the properties from the posted view model
       b.Name = model.Name;
       b.BioPhoto = GetByteArray(model.BioPhoto);
       // to do : Set other properties as well.
       db.Entry(business).State = EntityState.Modified;
       db.SaveChanges();
       return RedirectToAction("Index");
       
    }
    private byte[] GetByteArray(HttpPostedFileBase file)
    {
        if (file != null)
        {
           MemoryStream target = new MemoryStream();
           file.InputStream.CopyTo(target);
           return target.ToArray();
        }
        return null;
    }
