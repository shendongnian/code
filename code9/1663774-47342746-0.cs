    List<Country> countryList = new List<Country>();
    
    foreach (string line in lines)
    {
        string[] criteria = line.Split(',');
    
        countryList.Add(new Country(criteria[0],
    	                            criteria[1],
    								Convert.ToInt32(criteria[2]))
    }
	
	Console.WriteLine($"Countries in countryList: {countryList.Count}.");
    
    foreach ( Country country in countryList)
    {
    	Console.WriteLine($"Name: {country.Name}, Capital: {country.Capital}, Population: {country.Population}.");
    }
