    var output = new ZipInfoEntity
    {
        Zip = results.First().Zip,
        StateName = results.First().StateName,
        StateAbbr = results.First().StateAbbr,
        FipsCountyInfo = new List<FipsCountyInfoEntity>( 
            results.Select(z=>
                new FipsCountyInfoEntity {
                    Fips = z.Fips,
                    County = z.County
                }
            )
        )
    }
