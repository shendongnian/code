    public ActionResult Details()
    {
        ProfileContext db = new ProfileContext();
        var data = (from c in db.Profiles
                    where c.Id == 1
                    select c).FirstOrDefault();
        // or 
        data = db.Profiles.FirstOrDefault(x => x.Id == 1);
        return View(data);
    }
