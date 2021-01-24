    public async Task<List<WayPoint>> FindAddress(string address)
        {
            List<WayPoint> matchingWaypoints = new List<WayPoint>();
            // Use current location as a query hint so nearest addresses are returned.
            BasicGeoposition queryHint = new BasicGeoposition();
            queryHint.Latitude = this.CurrentLocation.Position.Latitude;
            queryHint.Longitude = this.CurrentLocation.Position.Longitude;
            Geopoint hintPoint = new Geopoint(queryHint);
            MapLocationFinderResult result =
               await MapLocationFinder.FindLocationsAsync(address.Trim(), hintPoint, 5);
            // If the query returns results, store in collection of WayPoint objects.
            string addresses = "";
            if (result.Status == MapLocationFinderStatus.Success)
            {
                int i = 0;
                foreach (MapLocation res in result.Locations)
                {
                    matchingWaypoints.Add(new WayPoint(i++, res.Address.FormattedAddress, res.Point.Position.Latitude, res.Point.Position.Longitude));
                }
            }
            return matchingWaypoints;
        } 
