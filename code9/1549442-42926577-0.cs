    // define the array of IDs you want to search
    var refIds = Models.Select(x => x.RefId_One).ToArray();
    var ids = Models.Select(x => x.Id).ToArray();
    
    // perform the queries to filter
    var allModelOne = Context.TAB_One.All(m => !refIds.Contains(m.Id));
    var anyModelTwo = Context.TAB_Two.Any(m => ids.Contains(m.Id));
    
    // filter models 
    var modelsToSave = model.Where(m => !allModelOne.Contains(m.Id) && !anyModelTwo.Contains(m.Id));
    
    // save them
    foreach(twoModel model in modelsToSave) {	
    	Context.TAB_Two.Add(model);
    }
