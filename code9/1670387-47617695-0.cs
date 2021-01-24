    // Setup sample data (keyed by Type, but could be Type's FullName or whatever really)
    Dictionary< Type, object> exampleTypes = new Dictionary<Type, object>();
    exampleTypes.Add(typeof(string), "a");
    exampleTypes.Add(typeof(float), 1.0f);
    
    // Get two bits of sample data
    dynamic first = exampleTypes[typeof(string)];
    dynamic second = exampleTypes[typeof(float)];
    // Apply calculation you are interested in
    dynamic bob = first + second;
    
    // OK, float + string results in string
    Console.WriteLine(bob.GetType());
