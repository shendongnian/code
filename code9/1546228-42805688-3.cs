    var examples = new List<dynamic>
    {
        new ExpandoObject(), // initially it does not have any properties
        new ExpandoObject()
    };
    for (int i = 0; i < examples.Count; i++)
    {
        examples[i].ExampleInt = i;
        // etc
    }
    for (int i = 0; i < examples.Count; i++) // we add new property
        examples[i].ExampleBoolean = i % 2 == 0;
    foreach(var example in examples)
        Console.WriteLine($"{example.ExampleInt} {example.ExampleBoolean}");
