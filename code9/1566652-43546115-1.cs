    public IEnumerable<Parts> PartsTableSearch(PartsTable table)
    {
        //Queries come in as comma separated string
        var partNameList = table.PartName?.Split(',');
        var seriesNameList = table.SeriesName?.Split(',');
    
        //Gets and generates the list of Parts
        var fullList = GetParts();
        var filters = new List<Expression<Func<Part, bool>>>
     
        foreach (var partName in partNameList)
        {
            filters.Add(p => p.PartName.ToLower().Contains(name.ToLower()));
        }
        foreach (var seriesName in seriesNameList)
        {
            filters.Add(p => p.Series.SeriesName.ToLower().Contains(seriesName.ToLower()));
        }
        
        Expression<Func<Part, bool>> filter = filters.OrTheseFiltersTogether();
    
        return fullList.Where(filter);
    }
