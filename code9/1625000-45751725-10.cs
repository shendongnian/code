    var zipInfo =  results.GroupBy(e => new { e.Zip, e.StateName, e.StateAbbr }).Select(e => new ZipInfoEntity
            {
                Zip = e.Key.Zip,
                StateName = e.Key.StateName,
                StateAbbr = e.Key.StateAbbr,
                FipsCountyInfo = e.Select(c => new FipsCountyInfoEntity
                {
                    Fips = c.Fips,
                    County = c.County
                }).ToList()
            });
