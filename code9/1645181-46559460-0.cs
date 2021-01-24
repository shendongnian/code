    if (searchTerm.Contains(" "))
    {
    	string[] terms = searchTerm.Split(' ');
    	examineQuery.And().GroupedOr(new List<string> { SearchableFieldToSearch }, terms);
    }
