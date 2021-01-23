        foreach (StationCategory stationCategory in productCatalog.Programming.StationCategory)
         {
            StringBuilder stationList = new StringBuilder();
            foreach (Station station in stationCategory.Station.Select(x=>x.StationName).Distinct())
             {
               stationList.Append(station.StationName + ",");
             }
             offer.FeatureList.Add(new Feature() { FeatureName = "<b>" + stationCategory.CategoryName + "</b>", Value = stationList.ToString().TrimEnd(',')});
         }
        
