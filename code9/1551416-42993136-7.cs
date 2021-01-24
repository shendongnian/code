    String dictName = "Dict1"; //Achieved through some code mechanism in my project.
    
    SomeClass obj = new SomeClass();
    
    // Get field info by name
    var dictField = obj.GetType().GetField(dictName);
    // Get dictionary interface object from field info using reflection
    var targetDict = dictField.GetValue(obj) as IDictionary;
    if (targetDict == null) // If field not initialized
    {
        // Initialize field using default dictionary constructor
        targetDict = dictField.FieldType.GetConstructor(new Type[0]).Invoke(new object[0]) as IDictionary;
        // Set new dictionary instance to 'Dict1' field
        dictField.SetValue(obj, targetDict);
    }
    
    targetDict.Add(3.5d, new int[] { 5, 10 });
