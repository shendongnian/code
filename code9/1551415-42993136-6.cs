        String dictName = "Dict1"; //Achieved through some code mechanism in my project.
        SomeClass obj = new SomeClass();
        // Get dictionary interface object of 'Dict1' field using reflection
        var targetDict = obj.GetType().GetField(dictName).GetValue(obj) as IDictionary;
        // Add key and value to dictionary
        targetDict.Add(3.5d, new int[] { 5, 10 });
