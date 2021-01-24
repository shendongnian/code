    var lastIndex = (page * pageSize);
    if (lastIndex > result.Total)
    {
        var itemsToReturn = (int) (result.Total - (lastIndex - pageSize));
        if (itemsToReturn < 1)
        {
            items = new List<LdapQueryItem>();
        }
        else
        {
            items = items.Take(itemsToReturn).ToList();
        }
    }	
	
	
