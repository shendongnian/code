    dynamic testObject = new LoggedPropertyAccess();
    string firstname = testObject.FirstName;
    string lastname = testObject.LastName;
    foreach (var propertyName in testObject.accessedPropertyNames) {
        Console.WriteLine(propertyName);
    }
    Console.ReadKey();
