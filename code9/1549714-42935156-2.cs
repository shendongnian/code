	public ActionResult ViewTrip(int id)
	{
		using (ApplicationDbContext db = new ApplicationDbContext())
		{
			var query = from t in db.Trips
			where t.TripId == id
			select t;
			var trip = query.FirstOrDefault();
			if (trip == null) { /* fail */ }
			return View(trip);
		}
	}
