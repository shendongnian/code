    static void circleOfLife()
    {
        for (int i = 0; i < person.Count; i++)
        {
            if(person[i] != null)
            {
                person[i].increaseAge();
            }
        }
        //Select all id of person having Age > 99
        var personIds = person.Where(p => p.Age > 99).Select(p => p.Id);
        person.RemoveAll(p => p.Age > 99); //or person.RemoveAll(p => personIds.Contains(p.Id));
        createPerson(personIds.Count());
    }
