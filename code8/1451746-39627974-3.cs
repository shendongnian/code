    using (Model.BlueData bd = new Model.BlueData())
    {
        Random rng = new Random();
    
        s = new Model.Solve()
        {
            LocationID = bd.Locations.Find(rng.Next(0, bd.Locations.Count())).LocationID,
            BillID     = bd.Bills.Find(rng.Next(0, bd.Bills.Count())).BillID,
            ProfileID  = bd.Profiles.Find(rng.Next(0, bd.Profiles.Count())).ProfileID
        };
        s.Bill = s.Location = s.Profile = null; //otherwise EF tries to create them
        bd.Solves.Add(s);
        bd.SaveChanges();
    
        s = bd.Solves
            .Where(u => u.SolveID == s.SolveID)
            .Include(u => u.Location)
            .Include(u => u.Profile)
            .Include(u => u.Profile.ProfileSamples)
            .Include(u => u.Bill)
            .FirstOrDefault();
    }
