    if (list1 != null)
    {
    	var keys = list2.Select(item => new { item.Name, item.Number }).ToHashSet();
    	list2.AddRange(list1.Where(item => !keys.Contains(new { item.Name, item.Number })));
    }
