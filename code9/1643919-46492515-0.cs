	Dictionary<string, int> usernameCollection = new Dictionary<string, int>();
		
	foreach(string name in namesTextFile)
	{
		string username = string.Concat(name.Split().Select(x => x.Length >= 4 ? x.Substring(0, 4) : x));
			
		if(usernameCollection.ContainsKey(username))
		{
			usernameCollection[username] = usernameCollection[username] + 1;
		}
		else
		{
			usernameCollection.Add(username, 1);
		}					
	}
