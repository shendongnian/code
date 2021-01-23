    private static readonly CultureInfo USCULTURE = new CultureInfo("en-US");
  
    // Go over all items
    foreach (string latlon in DeviceLocations)
    {
        // Get the split result
        string[] coordinates = latlon.Split(';');
        // Lat is first item of split array, Lon is second item
        double lat = Convert.ToDouble(coordinates[0], USCULTURE);
        double lon = Convert.ToDouble(coordinates[0], USCULTURE);
        // Now do something with the double values
        ...
    }
