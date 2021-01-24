	public static IEnumerable<string> DeDupeFileList(List<string> files)
	{
		List<string> ids = new List<string>();
		foreach(string f in files)
		{
			var split = f.Split('-');
			if(split.Length > 1)
			{
				if(!ids.Contains(split[1]))
				{
					ids.Add(split[1]);
					yield return f;
				}
			}
			else
			{
				continue;
			}
		}
	}
