    var nearbyOrganizations = _UoW.OrganisationRepo.All
         .Select(x => new 
          { //use an anonymous type or any type you want
              Org = x, 
              Distance = new GeoCoordinate(x.Latitude, x.Longitude).GetDistanceTo(userLocation) 
         })
         .ToEnumerable() //or .ToList() or .ToArray(), make sure it's outside of EF's reach (prevent SQL generation)
         .Where(x=> x.GeoCoordinate.GetDistanceTo(userLocation) < radius)
         .ToList();
