    String dictName = "Dict1"; //Achieved through some code mechanism in my project.
    
    SomeClass obj = new SomeClass();
    
    var dictField = obj.GetType().GetField(dictName);
    var targetDict = dictField.GetValue(obj) as IDictionary;
    if (targetDict == null)
    {
        targetDict = dictField.FieldType.GetConstructor(new Type[0]).Invoke(new object[0]) as IDictionary;
        dictField.SetValue(obj, targetDict);
    }
    
    targetDict.Add(3.5d, new int[] { 5, 10 });
