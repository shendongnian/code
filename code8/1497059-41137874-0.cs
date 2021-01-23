    List<Person> persons = ....
    var specificPerson = perons.Where(p => p.Name == something && p.Age == 0 somethingElse).FirstOrDefault();
    if (specificPerson != null) //We have a person in the list (I'm assuming Person is a class, not struct)
    {
        specificPerson.Name = updatedValue;
        specificPerson.Age = someOtherUpdatedValue;ç
        // etc.
    }
    else //Person is not in the list
    {
        var newPerson = new Person( ... );
        persons.Add(newPerson);
    }
