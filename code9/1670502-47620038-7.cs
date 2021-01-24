    [HttpPost]
    public ActionResult CreateFax(SendFaxVm model)
    {
       // check model.SelectedEmployees and other properties
       //  and use that to save data to your tables
       Fax f=new Fax();
       f.CompanyName = model.CompanyName;
       f.CompanyAddress = model.CompanyAddress;
       // to do : Assign other property values for the Fax table
       db.Fax.Add(f); 
       db.SaveChanges();
       //Now loop through the SelectedEmployees and save record for FaxData table
       foreach(var userId in model.SelectedEmployees)
       {
           var fd=new FaxData { EmpId = userId, FaxId=f.Id };
           //to do  : Save fd 
       }
       return RedirectToAction("Index");
    }
