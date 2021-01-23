    static void circleOfLife()
    {
        for (int i = 0; i < person.Count; i++)
        {
            if(person[i] != null)
            {
                person[i].increaseAge();
            }
        }
        person.RemoveAll(p => p.Age > 99)
        createPerson(10 - person.Count());
    }
