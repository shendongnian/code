    using System.Linq;
    using System.Collections.Generic;
    
    LicensePlateInformation plateInfo = await GetLicensePlateInfoFromAPI();
    List<Coordinate> coOrdinatesList = new List<Coordinate>();
    plateInfo.results.Select(x => x.coordinates).ToList().ForEach(y =>
    {
                    y.ForEach(z =>
                    {
                        coOrdinatesList.Add(z);
                    });
     });
