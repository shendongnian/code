    var type = typeof(object).MakeArrayType(1);
    // Create an instance with length 2
    var array = Activator.CreateInstance(type, 2);
    Console.WriteLine(array.GetType());            // System.Object[]
    Console.WriteLine(type);                       // System.Object[*]
