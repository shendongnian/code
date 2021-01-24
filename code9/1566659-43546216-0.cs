    public IEnumerable<Parts> PartsTableSearch(PartsTable table)
    {
        //Queries come in as comma separated string
        var partNameList = table.PartName?.Split(',');
        var seriesNameList = table.SeriesName?.Split(',');
    
        //Gets and generates the list of Parts
        var fullList = GetParts();
    
        if (partNameList != null && partNameList.Length > 0)
        {        
            foreach (var partName in partNameList)
            {
                yield return fullList.Where(p => p.PartName.ToLower().Contains(name.ToLower()));
            }
        }
        if (seriesNameList != null && seriesNameList.Length > 0)
        {
            foreach (var seriesName in seriesNameList)
            {
                yield return fullList.Where(p => p.Series.SeriesName.ToLower().Contains(seriesName.ToLower()));
            }
        }
    
      yield return null;
    }
