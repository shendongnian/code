    object o1 = new []{ 1, 2, 3, 4, 5 };
    IList<int> l1;
    if (TryCastAsList(o1, out l1))
    {
        int n = l1.First(); // 1
    }
    
    object o2 = new[] { "Hello", "World" };
    IList<string> l2;
    if (TryCastAsList(o2, out l2))
    {
        string s = l2.First();  // Hello
    }
