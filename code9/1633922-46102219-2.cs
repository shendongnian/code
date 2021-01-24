	private static string NextInString(List<string> names, string userName)
	{		
		int index = names.IndexOf(userName);
				
		if(names.Count - 1 == index || index == -1)
		{
			return "No result";
		}
		else
		{
			return names[index + 1];
		}
	}
