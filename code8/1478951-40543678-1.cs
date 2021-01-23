        foreach (StationCategory stationCategory in productCatalog.Programming.StationCategory)
         {
            StringBuilder stationList = new StringBuilder();
            foreach (var stationName in stationCategory.Station.Select(x=>x.StationName).Distinct())
             {
               stationList.Append(stationName + ",");
             }
             offer.FeatureList.Add(new Feature() { FeatureName = "<b>" + stationCategory.CategoryName + "</b>", Value = stationList.ToString().TrimEnd(',')});
         }
        
