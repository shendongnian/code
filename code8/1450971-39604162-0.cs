    public Person RetrievePerson(string name)
    {
        var memoryCache = MemoryCache.Default; // Needs a reference to System.Runtime.Caching
        var person = memoryCache.Get(name) as Person;
        if (person == null)
        {
            person = CreatePerson(name);
            memoryCache.Add(name, person, new CacheItemPolicy
            {
                SlidingExpiration = new TimeSpan(0, 0, 1)
            });
        }
        return person;
    }
