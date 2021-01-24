        String dictName = "Dict1"; //Achieved through some code mechanism in my project.
        SomeClass obj = new SomeClass();
        // Get field 'Dict1' dictionary interface using reflection
        var targetDict = obj.GetType().GetField(dictName).GetValue(obj) as IDictionary;
        // Add key and value to dictionary
        targetDict.Add(3.5d, new int[] { 5, 10 });
