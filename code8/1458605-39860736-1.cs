    static void Main(string[] args)
    {
        List<Person> persons = new List<Person>
        {
            new Person { Age = 1 },
            new Person { Age = 2 },
            new Person { Age = 5 }
        };
        long total = 0;
        Parallel.ForEach(persons, person => Add(person, ref total));
        Console.WriteLine(total);
        Console.ReadKey();
    }
    public static void Add(Person person, ref long shared)
    {
        // since here you access a shared variabe, we
        // can use the Interlocked class in order our operation
        // to be atomic. 
        Interlocked.Add(ref shared, person.Age);
    }
