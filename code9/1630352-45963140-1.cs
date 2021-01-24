    dynamic duck = new DuckFactory().GetDuck();
    //  Check the property exists before using it
    if (((IDictionary<string, Object>)duck).ContainsKey("Name"))
    {                
        Console.WriteLine(duck.Name);   //  Prints Fauntleroy
    }
    else
    {
        Console.WriteLine("Poor duck doesn't have a name.");
    }
