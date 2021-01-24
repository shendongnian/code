            List<string>licenseTypeArray = Regex.Split(availableLicensesTypes, "\n").ToList();
            List<string> totalLicenseArray = Regex.Split(totalLicenses, "\n").ToList();
            List<string> consumedLicenseArray = Regex.Split(consumedLicenses, "\n").ToList();
            //A generic list of the new entity class that wraps the three properties (columns)
            List<LicenseInfo> licensesList = new List<LicenseInfo>();
            //concat zip the three lists with a comma-separated for each entry in the new list with this pattern ("License Type, Total Count, Consumed Count"). 
            //Example("Entrprise License,200,50")
            List<string> licensesConcatenatedList = licenseTypeArray.Zip(totalLicenseArray.Zip(consumedLicenseArray, 
                (x, y) => x +","+ y), 
                (x1,y1) => x1 + "," + y1).ToList();
            
            licensesConcatenatedList.ForEach(t => licensesList.Add(new LicenseInfo
            {
                LicenseType = t.Split(new char[] { ',' })[0],
                TotalLicenesesCount = int.Parse(t.Split(new char[] { ',' })[1]),
                ConsumedLicensesCount = int.Parse(t.Split(new char[] { ',' })[2])
            }));
