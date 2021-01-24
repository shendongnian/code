    public List<ListItem> getSortedList()
	{
		int dummy = 0;
		
		List<ListItem> list = new List<ListItem>();
		list.Add(new ListItem() { Item = "A" });
		list.Add(new ListItem() { Item = "B" });
		list.Add(new ListItem() { Item = "C" });
		list.Add(new ListItem() { Item = "111" });
		list.Add(new ListItem() { Item = "11" });
		list.Add(new ListItem() { Item = "123" });
		list.Add(new ListItem() { Item = "1" });
		list.Add(new ListItem() { Item = "42" });
		list.Add(new ListItem() { Item = "5" });
		
		var listNumber = list.Where(m => int.TryParse(m.Item, out dummy)).ToList().OrderBy(m => Convert.ToInt16(m.Item)).ToList();
		var listString = list.Where(m => !int.TryParse(m.Item, out dummy)).ToList().OrderBy(m => m.Item).ToList();
		
		var sortedList = listNumber.Concat(listString).ToList();
		
		return sortedList;
	}
