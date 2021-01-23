    // Use an untyped list which stores System.Object objects
    ArrayList list = new ArrayList();
    list.Add(1);
    list.Add(2);
    list.Add(4);
    list.Add(8);
    foreach (int x in list) { // C# inserts a cast for you
        Console.WriteLine(x);
    }
