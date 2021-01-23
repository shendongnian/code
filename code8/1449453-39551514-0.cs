    // Initialize list of roles and "Basic" beforehand
    // as it should be added at any case.
	List<string> mt = new List<string> { "Basic" };
    // Add additional roles as needed
	switch (n)
	{
		case 1:
			mt.Add("Reader");
			break;
		case 2:
			mt.Add("Blogger");
			break;
		case 3:
			mt.Add("Editor");
			break;
	}
	if (mt!= null)
	{
		result = await UserManager.AddToRolesAsync(user.Id, mt.ToArray());
	}
