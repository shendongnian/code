    public IEnumerable<Parts> PartsTableSearch(PartsTable table)
    {
        var fullList = GetParts();
        var filters = new List<Expression<Func<Part, bool>>>();
        if (table.PartName != null)
        {
            var partNameList = table.PartName.Split(',');
            foreach (var partName in partNameList)
            {
                filters.Add(p => p.PartName.ToLower().Contains(partName.ToLower()));
            }
        }
        if (table.SeriesName != null)
        {
            var seriesNameList = table.SeriesName.Split(',');
            foreach (var seriesName in seriesNameList)
            {
                filters.Add(p => p.Series.SeriesName.ToLower().Contains(seriesName.ToLower()));
            }
        }
        
        Expression<Func<Part, bool>> filter = filters.OrTheseFiltersTogether();
    
        return fullList.Where(filter);
    }
