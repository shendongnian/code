	var found = new HashSet<string>();
	
	IEnumerable<string> Mutate(string current)
	{
		for (var i = 0; i < current.Length; i++)
		{
			var sb = new StringBuilder(current);
			sb[i] = sb[i] == '0' ? '1' : '0';
			var r = sb.ToString();
			if (!found.Contains(r))
			{
				found.Add(r);
				yield return r;
				foreach (var r2 in Mutate(r))
				{
					yield return r2;
				}
			}
		}
	}
	
	var results = Mutate("00000").ToArray();
