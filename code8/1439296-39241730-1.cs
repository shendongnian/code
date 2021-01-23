    if (entity.Type == "Place")
    {
        Place place = entity.GetAs<Place>();
        GeoCoordinates geoCoord = place.Geo.ToObject<GeoCoordinates>();
        // geoCoord object will contains Longtitude & Latitude
    }  
 
