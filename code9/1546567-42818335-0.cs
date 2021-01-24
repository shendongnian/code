    TestClass test1 = new TestClass() { ID = 1, text = "STRING ONE" };
    TestClass test2 = new TestClass() { ID = 2, text = "STRING TWO" };
    TestClass test3 = new TestClass() { ID = 3, text = "STRING THREE" };
    TestClass test4 = new TestClass() { ID = 4, text = "STRING FOUR" };
    
    List<TestClass> lstTestClasses = new List<TestClass>();
    lstTestClasses.Add(test1);
    lstTestClasses.Add(test2);
    lstTestClasses.Add(test3);
    lstTestClasses.Add(test4);
    
    List<string> lstCategories = new List<string>() { "STRING TWO", "STRING ONE", "STRING THREE" };
    
    var orderStrings = lstTestClasses.OrderBy(x => {
        var index = lstCategories.IndexOf(x.text);
        return index < 0 ? Int32.MaxValue : index;
    }).ToList();
    
    foreach (var item in orderStrings)
    {
        Console.WriteLine(item.text);
    }
