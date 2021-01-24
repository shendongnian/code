	public static TParameter CreateParameter<TParameter>(IParameterList<TParameter> db) where TParameter : IParameter, new()
	{
		var r = new TParameter(); // This is the generic function you mentioned. Do stuff here to create your Parameter class.
		db.ParameterList.Add(r); // Add the newly created parameter to the correct list
		return r;
	}
