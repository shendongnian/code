	// I guessed that it is an int, change it accordingly
	var tableOneLookup = new HashSet<int>(Context.TAB_One.Id.Select(x => x.Id));
	var tableTwoLookup = new HashSet<int>(Context.TAB_Two.Id.Select(x => x.Id));
	// example of checking (check based on code you had shown before)
	var modelsNotInTabOne = Models.Where(model => !tableOneLookup.Contains(model.RefIdOne)).ToList();
	var modelsNotInTabTwo = Models.Where(model => !tableOneLookup.Contains(model.Id)).ToList();
	// now do something with the results like create entity instances
