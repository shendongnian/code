    var seenCompanies = new List<string>();
    foreach(var line in csvFile)
    {
    	seenCompanies.Add(line.GetColumn("companyName"));
    }
    
    var companiesAndCounts = 
    	seenCompanies
    	.GroupBy(s => s)
    	.Select(group => new { Name = group.Key, Count = group.Count()})
    	.ToList();
    	
    foreach(var group in companiesAndCounts)
    {
    	outputFile.Write(group.Name + "," + group.Count);
    }
