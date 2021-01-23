    List<Person> persons = ....
    var specificPerson ? Perons.Where( p => p.Name == something && p.Age == 0 somethingElse).FirstOrDefault();
    if (specificPerson != null)
    {
        persons.Remove(specificPerson);
    }
    var newPerson = new Person( /*new data*/ );
    persons.Add(newPerson);
