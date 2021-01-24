    var agents = db.AllAgentLocations()
        .AsEnumerable()
        .Where(al => al.PrimaryOffice)
        .Select(al => new AgentDistanceViewModel {
            Agent = al.Agent,
            Distance = searchCoords.GetDistanceTo(
                new GeoCoordinate {
                    Latitude = double.Parse(al.Location.Latitude),
                    Longitude = double.Parse(al.Location.Longitude)
                }
            ) / 1609.34
        })
        .Where(dvm => 25 >= dvm.Distance)
        // ...
