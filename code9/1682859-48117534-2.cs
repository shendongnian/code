    border
        .Aggregate(new BorderBounds() 
                 { MinLatitude = double.MaxValue, 
                   MinLongitude = double.MaxValue, 
                   MaxLongitude = double.MinValue, 
                   MaxLatitude = double.MinValue }, 
                   (current, next) => new BorderBounds {
                       MinLatitude = next.Latitude < current.MinLatitude ? next.Latitude : current.MinLatitude,
                       MinLongitude = next.Longitude < current.MinLongitude ? next.Longitude : current.MinLongitude,
                       MaxLatitude = next.Latitude > current.MaxLatitude ? next.Latitude : current.MaxLatitude,
                       MaxLongitude = next.Longitude > current.MaxLongitude ? next.Longitude : current.MaxLongitude
                    } 
         ); 
