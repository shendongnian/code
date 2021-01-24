    public IEnumerable<Parts> PartsTableSearch(PartsTable table)
    {
        //Queries come in as comma separated string
        var partNameList = table.PartName?.Split(',');
        var seriesNameList = table.SeriesName?.Split(',');
        //Gets and generates the list of Parts
        var fullList = GetParts()
		    .Where(p => partNameList.Any(n => n.Contains(p.PartName.ToLower())))
			    || seriesNameList.Any(n => n.Contains(p.Series.SeriesName.ToLower())))
		    .ToList();
        return fullList;
    }
