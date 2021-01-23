    public void TestObject(Person person)
    { 
        person = new Person { Name = "Two" };
    }
    public void TestObjectByRef(ref Person person)
    { 
        person = new Person { Name = "Two" };
    }
