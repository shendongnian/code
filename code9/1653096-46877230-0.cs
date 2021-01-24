    [Test]
    public void Some_Name()
    {
        var person = new Mock<Person>() { CallBase = true };
        person.Setup(x => x.Age = 20);
        var employee = new Employee();
        var result = employee.IsAdult();
    }
