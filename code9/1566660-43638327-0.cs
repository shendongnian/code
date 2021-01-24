    var fullList = GetParts();        
    if (partNameList != null && partNameList.Length > 0)
            {
                var tempList = new List<Parts>();
                foreach (var partName in partNameList)
                {
                    tempList.AddRange(fullList.Where(p => p.PartName.ToLower().Contains(partName.ToLower().Trim())));
                }
                fullList = tempList;
            }
            if (seriesNameList != null && seriesNameList.Length > 0)
            {
                var tempList = new List<Parts>();
                foreach (var seriesName in seriesNameList)
                {
                    tempList.AddRange(fullList.Where(p => p.Series.SeriesName.ToLower().Contains(seriesName.ToLower().Trim())).ToList());
                }
                fullList = tempList;
            }
    return fullList.ToList();
