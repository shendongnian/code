    ActionCollection.Add(new AnnotatedVal("hello", "Area"), someDictionary);
    if (ActionCollection.ContainsKey(new AnnotatedVal("hello", "Area"))) {
        Console.WriteLine("Yes");
    } else {
        Console.WriteLine("No");
    }
    if (ActionCollection.ContainsKey(new AnnotatedVal("hello", "Controller"))) {
        Console.WriteLine("Yes");
    } else {
        Console.WriteLine("No");
    }
