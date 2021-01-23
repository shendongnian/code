    var person = new Person { name = One };
    TestObject(person);
    Console.WriteLine(person.Name); // will print One
    TestObjectByRef(person);
    Console.WriteLine(person.Name); // will print Two
