    typeof(SomeClass).GetCustomAttributes(false);//without this line, GetHashCode behaves as expected
    SomeAttribute tt = new SomeAttribute();
    foreach (var field in new SomeAttribute().GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
    {
        Console.WriteLine(field.Name);
    }
    
    Console.WriteLine(tt.GetHashCode());//Prints 0
    Console.WriteLine(tt.GetHashCode());//Prints 0
    Console.WriteLine(tt.GetHashCode());//Prints 0
    
    foreach (var field in new SomeAttribute().GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
    {
        Console.WriteLine(field.Name);
    }
