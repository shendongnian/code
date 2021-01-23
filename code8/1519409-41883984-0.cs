    Person p = ServiceReference1.Person{Name="Peter"};
    ServiceReference2.Person p2 = new ServiceReference2.Person() {
        Property1 = p.Property1,
        Property2 = p.Property2,
        // and so on
    };
    new Service2Client().AddPerson2(p2);
