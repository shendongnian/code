    if (kmlLayer.Containers != null)
    {
        foreach (KmlContainer container in kmlLayer.Containers.ToEnumerable())
        {
            foreach (var property in container.Properties.ToEnumerable())
            {
                //This is a Java HashMap<string, string> ....
                Log.Debug(Constants.TAG, $"{property.ToString()} : {container.GetProperty(property.ToString())}"); 
            }
            foreach (KmlPlacemark placemark in container.Placemarks.ToEnumerable())
            {
                Log.Debug(Constants.TAG, placemark.ToString());
            }
        }
    }
