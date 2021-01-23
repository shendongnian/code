	string[] stringrray = { "cat", "cats", "catsdogcats", "catxdogcatsrat", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" };
	List<string> list2 = new List<string>(stringrray);
	List<string> Finallist = new List<string>();
	char[] smallstrchar = String.Join("", list2.Where(x => x.Length <= 4)).ToCharArray();
	char[] Bigstrchar = String.Join("", list2.Where(x => x.Length > 4)).ToCharArray();
	char[] modchar = Bigstrchar.Except(smallstrchar).ToArray();
	foreach(string bigstr in list2)
	{
		if(!(bigstr.IndexOfAny(modchar) != -1))
		{
			Finallist.Add(bigstr);
		}
	}
	Finallist = Finallist.OrderByDescending(x => x.Length).Take(2).ToList();
	foreach(string finalstr in Finallist)
	{
		Console.WriteLine(finalstr);
	}
