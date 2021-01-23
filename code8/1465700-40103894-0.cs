	string typeString = "My.Assembly.Namesapce.MyClass, My.Assembly.Namesapce, Version=4.0.0.0, Culture=neutral, PublicKeyToken=84474dc3c6524430";
    // Get a reference to the type.
	Type theType = Type.GetType(typeString, true, false);
    // Create an instance of that type.
	MyClass  theInstance = (MyClass)Activator.CreateInstance(theType);
