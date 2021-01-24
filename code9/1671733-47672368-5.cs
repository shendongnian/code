    using System.Linq;
    using System.Collections.Generic;
    
    LicensePlateInformation plateInfo = await GetLicensePlateInfoFromAPI();
    List<Coordinate> coOrdinatesList = new List<Coordinate>();
     foreach (var outerItem in plateInfo.results.Select(x => x.coordinates))
     {
           foreach (var innerItem in outerItem)
           {
              coOrdinatesList.Add(innerItem);
           }
     }
