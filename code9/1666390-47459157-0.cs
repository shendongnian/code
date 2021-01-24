     foreach(var item in context.ModelState)
     {
        string parameter = item.Key;
        object rawValue = item.Value.RawValue;
        string attemptedValue = item.Value.AttemptedValue;
        System.Console.WriteLine($"Parameter: {parameter}, value: {attemptedValue}");
     }
