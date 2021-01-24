    var list = (from v in db.VehicleLocation.Where(x.VehicleId == vehicleId)
    			from v2 in db.VehicleLocation.Where(x.VehicleId == vehicleId)
    			where v.DateTimestamp > v2.previoustimestamp
    			group v2 by new { v.Id, v.Location, v.DateTimestamp } into sub
    			select new VehicleLocationModel
    			{
    				Id = sub.Key.Id,
    				Location = sub.Key.Location,
    				DateTimestamp = sub.Key.DateTimestamp,
    				DiffTimestamp = sub.Key.DateTimestamp - sub.Max(x => x.DateTimestamp)
    			}).OrderBy(x => x.DateTimestamp).ToList();
