		List<string> list = new List<string>();
		if (list.Count >= X)
		{
			list.RemoveAt(0);
		}
		list.Add(newString);
		return list.Count >= X && list.Any(s => s == list[0]);
