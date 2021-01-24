	var yourSharedModel = new YourSharedModel();
	yourSharedModel.Models.Add(itemA);
	yourSharedModel.Models.Add(itemB);
	// etc
	var validator = new SharedModelValidator();
	var results = validator.Validate(yourSharedModel);
	if (!results.IsValid)
	{
		// do something with results.Errors
	}
