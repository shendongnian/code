    //assuming using Newtonsoft
    
    var myJson = ....assuming one Country;
    var countryJson = JsonConvert.DeserializeObject<CountryJson>(myJson);
    //Write a Mapper Or Manual Map like below
    var countryEntity = new Country 
    {
        Name = countryJson.Name,
        ...
        TopLevelDomains = JsonConvert.Serialize(countryJson.TopLevelDomains),
        CallingCodes = JsonConvert.Serialize(countryJson.CallingCodes),
        ...//same for all list (NOTE: YOU NEED TO DESERIALIZE IT WHEN YOU FETCH IT FROM DB
        Longitude = countryJson.Latlng.ElementAt(0),//assuming 0 is longi, 1 is lat
        Latitude = countryJson.Latlng.ElementAt(1)//you can do it like above as well as string if you want
    }
