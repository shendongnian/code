    public static List<Person> FindModifiedPeople(Dictionary<int, Person> dictA, Dictionary<int, Person> dictB)
    {
        var modifiedPeople = new List<Person>();
        foreach (var personA in dictA)
        {
            Person matchingPerson;
            if(dictB.TryGetValue(personA.Key, out matchingPerson))
            {
                if (!personA.Value.IsEqual(matchingPerson))
                {
                    modifiedPeople.Add(personA.Value);
                }
            }
        }
        return modifiedPeople;
    }
