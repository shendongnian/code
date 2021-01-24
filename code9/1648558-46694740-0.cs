    public ActionResult GetTechnicians(string branch, string status)
    {
        var data = unitOfWork.TechnicianRepository.GetAll()
                       .Where(c => c.Branch == "Calgary")
                       .Where(a => a.ActivityStatus == "Active")
                       .Select(t => new TechnicianViewModel
                       {
                           Id = t.UserId,
                           UserName = t.UserName,
                           Bio = t.Bio
                       });
        ...
    }
