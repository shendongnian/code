            Geolocator geoLocator = new Geolocator();
            GeolocationAccessStatus accessStatus = await Geolocator.RequestAccessAsync();
            
            if ( accessStatus == GeolocationAccessStatus.Allowed)
            {
                // Put all your Code here to access location services
                Geoposition geoposition = await geoLocator.GetGeopositionAsync();
                var position = geoposition.Coordinate.Point.Position;
                var latlong = string.Format("lat:{0}, long:{1}", position.Latitude, position.Longitude);
            }
            else if (accessStatus == GeolocationAccessStatus.Denied)
            {
                   // No Accesss
            }
            else
            {
            }
