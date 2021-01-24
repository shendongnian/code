    ActionResult View(int id)
    {
        using (ApplicationDbContext _db = new ApplicationDbContext())
        {
            var trip = (from Trips in _db.Trips where Trips.TripId.Equals('1') select Trips.TripId);
    
            if (trip == null)
                return HttpNotFound();
        
            return View()
        }
    }
