     public IEnumerable<Location> GetChild(int id)
            {
                DBEntities db = new DBEntities();
            var locations = db.Locations.Where(x => x.ParentLocationID == id || x.LocationID == id).ToList();
        
        var child = locations.AsEnumerable().Union(
                                    db.Locations.Where(x => x.ParentLocationID == id).SelectMany(y => GetChild(y.LocationID))).ToList();
                return child;
            }
