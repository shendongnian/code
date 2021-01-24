    Dim RegionDictionary As New Dictionary(Of Integer, Region)
    Await Database.QueryAsync(Of Region, Country, CountryAlias, Region)(sql,
    Function(region, country, countryalias)
        Dim _region As New Region();
        if(!RegionDictionary.TryGetValue(region.RegionID, _region)) Then
            _region = region
            RegionDictionary.Add(region.RegionID, region)
            If IsNothing(_region.Countries) Then
                _region.Countries = new List(Of Country)
            End If
            If Not IsNothing(countryalias) Then
                ' begin <this line might be discarded>
                If IsNothing(country.CountryAliases) Then
                    country.CountryAliases = new List(Of CountryAlias)
                End If
                ' end
                country.CountryAliases.Add(countryalias)
            End If
            _region.Countries.Add(country)
        End If
    End Function, New With {channelID}, splitOn: "CountryID, CountryAliasID, RegionID")
    Return RegionDictionary.Values.ToList()
