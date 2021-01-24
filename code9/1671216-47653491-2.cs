    foreach (var region in allRegionGroups)
    {
        string geographyName = region.GeographyName;
        var allCountries = region.Countries;
        foreach (var c in allCountries)
        {
            string country = c.Country;
            var allStates = c.States;
            //  and so on...
        }
    }
