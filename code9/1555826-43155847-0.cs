    public IEnumerable<Person> GetPeopleListLongOperation()
    {
        // forcing "long" data load
        Thread.Sleep(5000);
        yield return new Person();
    }
