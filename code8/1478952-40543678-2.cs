        foreach (StationCategory stationCategory in productCatalog.Programming.StationCategory)
         {
            StringBuilder stationList = new StringBuilder();
            foreach (var stationName in stationCategory.Station.GroupBy(x => x.Name).Select(x => x.First()))
             {
               stationList.Append(stationName + ",");
             }
             offer.FeatureList.Add(new Feature() { FeatureName = "<b>" + stationCategory.CategoryName + "</b>", Value = stationList.ToString().TrimEnd(',')});
         }
        
