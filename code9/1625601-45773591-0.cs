    using (respStream = resp.GetResponseStream())
    {
        location = new WeatherData.Location.LocationData();
    
        XmlDocument xml = Utility.retrieveXMLDocFromResponse(respStream, "/weatherdata");
        location.country = xml.GetElementsByTagName("country")[0].InnerText;
        location.name = xml.GetElementsByTagName("name")[0].InnerText;
    
        forecastList = new List<WeatherData.Forecast.Time>();                       
        XmlNodeList xnlTNodes = xml.DocumentElement.SelectNodes("/weatherdata/forecast/time");
        foreach (XmlNode xmlTimeNode in xnlTNodes)
        {
            WeatherData.Forecast.Time time = new WeatherData.Forecast.Time();
            time.from = xmlTimeNode .GetAttribute("from");
            time.to = xmlTimeNode .GetAttribute("to");                           
            time.clouds = xmlTimeNode["clouds"].GetAttribute("value");
            time.precipitation = xmlTimeNode["precipitation"].GetAttribute("type");
             forecastList.Add(time);
         }
        
    }
