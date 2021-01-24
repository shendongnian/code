	// create lists of just the ids
	var modelOneIds = Models.Select(model => model.RefIdOne).ToList();
	var modelTwoIds = Models.Select(model => model.Id).ToList();
	// create a list of ids found in the db
	var foundInTableOne = new List<int>();
	var foundInTableTwo = new List<int>();
	
	// iterate over the model in batches of 1000, the translated IN clause in Sql has a limit. You can tweak this number accordingly
	const int batchSize = 1000;
	for(int i = 0; i < Models.Count; i+=batchSize){
		var tmpModelOneIds = modelOneIds.Skip(i).Take(batchSize).ToList();
		var tmpModelTwoIds = modelTwoIds.Skip(i).Take(batchSize).ToList();
		
		foundInTableOne.AddRange(Context.TAB_One.Where(itm => tmpModelOneIds.Contains(itm.Id)).Select(itm => itm.Id));
		foundInTableTwo.AddRange(Context.TAB_Two.Where(itm => tmpModelTwoIds.Contains(itm.Id)).Select(itm => itm.Id));
	}
	// find the models not found in the DB
	var modelsNotInTabOne = Models.Where(model => !foundInTableOne.Contains(model.RefIdOne)).ToList();
	var modelsNotInTabTwo = Models.Where(model => !foundInTableTwo.Contains(model.Id)).ToList();
	
	// now do something with the results like create entity instances
