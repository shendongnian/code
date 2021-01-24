	string[] fields = new string[] { pocoModel.Name, pocoModel.Street, pocoModel.City, pocoModel.State };
	bool isValid = true;
	foreach (string field in fields)
	{
		if (string.IsNullOrEmpty(field))
		{
			isValid = false;
			break;
		}
	}
	if (isValid)
	{
		// Code here
	}
