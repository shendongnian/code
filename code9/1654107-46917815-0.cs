    [HttpPost]
    public JsonResult Save(BranchRegistration branchRegistration)
    {
        branchRegistration.CreatedDateTime =  DateTime.UtcNow;
        branchRegistration.UpdatedDateTime =  DateTime.UtcNow;
        using (var entities = new BranchContext())
        {
            entities.branch.Add(branchRegistration);
            entities.SaveChanges();
        }
    
        return Json(branchRegistration);
    }
