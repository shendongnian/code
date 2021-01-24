    var copy = toIterate.ToList();
    copy.Sort();
    
    // iterate through the sorted List
    foreach (GeneratorObject field in copy)
    {
    	// get the original object regarding to this sorted item
    	GeneratorObject originalObjectForAction = getGeneratorObject(toIterate, field);
    	// do stuff with the original item
    }
    
    public GeneratorObject getGeneratorObject(ObservableCollection<GeneratorObject> list, GeneratorObject objekt)
    {
    	foreach (DwhRoboterGeneratorObjekt field in list)
    	{
    		if (field == objekt) return field;
    	}
    	throw new Exception("Not found");
    }
