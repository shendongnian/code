    [Authorize]
    [HttpPost]
    public ActionResult updateMember(Member m)
    {
        Model1 db = new Model1();
        Member bamc = db.Members.FirstOrDefault(t => t.MemberId == m.MemberId);
        // Update member        
        bamc.Name = m.Name;
        bamc.Address = m.Address;
        // … etc. ...
        
        db.Entry(bamc).State = EntityState.Modified;
        db.SaveChanges();
        return View("MemberDetails", m);
    }
