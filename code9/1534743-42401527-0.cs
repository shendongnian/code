	foreach (string key in Application.AllKeys)
	{
		int id;
		if (Int32.TryParse(key, out id))
		{
			if (!MyList.Any(l => l.Id == id))
			{
				Application.Remove(key);
			}
		}
	}
