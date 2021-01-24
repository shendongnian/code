    Dictionary<int, Region> RegionDictionary = new Dictionary<int, Region>();
    Await Database.QueryAsync<Region, Country, CountryAlias, Region>(sql,
        (region, country, countryalias) => {
        Region _region = new Region();
        
        if(!RegionDictionary.TryGetValue(region.RegionID, out _region)){
            RegionDictionary.Add(region.RegionID, _region = region);
        }
        
        if(_region.Countries == null){
            _region.Countries = new List<Country>();
        }
        if(countryalias != null){
            // begin <this line might be discarded>
            if(country.CountryAliases == null){
                country.CountryAliases = new List<CountryAlias>();
            }
            // end
            country.CountryAliases.Add(countryalias);
        }
        _region.Countries.Add(country);
        return _region;
    }, new {channelID}, splitOn: "CountryID, CountryAliasID, RegionID");
    
    return RegionDictionary.Values.ToList();
