    static void Main(string[] args)
    {
        List<Person> people = new List<Person>()
        {
            new Person("Sam", 23, GenderType.M, "USA"),
            new Person("Jon", 13, GenderType.M, "USA"),
            new Person("Jen", 26, GenderType.F, "USA"),
            new Person("Thilini", 25, GenderType.F, "Sri Lanka"),
            new Person("Anna", 23, GenderType.F, "UK"),
            new Person("Chelsea", 35, GenderType.F, "UK"),
            new Person("Saman", 43, GenderType.M, "Sri Lanka"),
            new Person("Dan", 27, GenderType.M, "UK")
        };
        Dictionary<GenderType, Dictionary<string, List<Person>>> groups =
            people.GroupBy(p => p.Gender).ToDictionary(g => g.Key,
                g1 => g1.GroupBy(p => p.Country).ToDictionary(g2 => g2.Key, g2 => g2.ToList()));
        Console.ReadLine();
    }
