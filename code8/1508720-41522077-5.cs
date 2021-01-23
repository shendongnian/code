    var person = new Person { name = "One" };
    TestObject(person);
    Console.WriteLine(person.Name); // will print One
    TestObjectByRef(ref person);
    Console.WriteLine(person.Name); // will print Two
