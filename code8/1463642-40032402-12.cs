    public Location GetXmlData(string url)
    {
        Location loc;
        using(var wc = new WebClient())
        {
            // Type you want to deserialize
            var ser = new XmlSerializer(typeof(WeatherData));
            using(var stream = wc.OpenRead(url))
            {   
                // create the object, cast the result
                var w = (WeatherData) ser.Deserialize(stream);
                // w.Dump(); // linqpad testing
                // what do we need
                loc =  w.Product.ForeCasts.First().Location;
            }
        }
        return loc;
    }
    
