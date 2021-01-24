    MyObject mobj = new MyObject();
	mobj.MyProperty = new List<UserQuery.AnotherObject>();
	mobj.MyProperty.Add(new AnotherObject());
	mobj.MyProperty.Add(new AnotherObject());
	mobj.MyProperty.Add(new AnotherObject());
	mobj.MyProperty.Add(new AnotherObject());
	mobj.MyProperty.Add(new AnotherObject());
	mobj.MyProperty.Add(new AnotherObject());
	
	
	List<MyObject> splitList = new List<MyObject>();
	
	for (int i = 0; i < mobj.MyProperty.Count; i++)	
	{   
        // get the reference to the object from the list
		AnotherObject temp = mobj.MyProperty[i];
        // make a deep copy of the base object
		MyObject clone = mobj.Clone() as MyObject;
        // overwrite the internal list and put the reference to the item into the list
		clone.MyProperty = new List<AnotherObject> {temp};
        // add the copied object to the split list
		splitList.Add(clone);
	}
