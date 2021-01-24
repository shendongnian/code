    List<int> activeLockers = results.LockerList.Select(al => al.LockerId).ToList();
	using (var dbc = new MyDBContext())
	{
	    dbc.PickupLocations.Where(pl => !activeLockers.Contains(pl.ExternalID)).ToList().ForEach(x => x.Status=0);
	    dbc.SaveChanges();
	}
