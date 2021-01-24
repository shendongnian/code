    while(files.Any(f => f.Repeat > 0))
	{
		foreach(var f in files)
		{
			if(f.Repeat > 0)
			{
				checkItem.Add(f.FileName);
				f.Repeat--;
			}
		}
	}
    if(checkItem.Count > 0)
    {
        foreach (var item in checkItem)
            Console.WriteLine(item);
    }
