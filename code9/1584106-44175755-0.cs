        interface MyInterface
        {
            public string Name { get; set; }
        }
        class Person : MyInterface
        {
            public string Name { get; set; }
        }
        class Animal : MyInterface
        {
            public string Name { get; set; }
        }
    Now use the interface for your list:
        var result = reflection.GetResultFromMethodInvoked<MyInterface>("Person", "PersonRepository", "GetPersons");
        foreach(var o in result) // o now is of type MyInterface
