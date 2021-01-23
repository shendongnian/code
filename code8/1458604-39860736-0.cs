    static void Main(string[] args)
    {
        List<Person> list = new List<Person> 
        { 
            new Person { Age = 1 }, 
            new Person { Age = 2 }, 
            new Person { Age = 5 } 
        };
        
        long total = 0;
        Parallel.ForEach(list, 
            () => 0, 
            (person, loop, subtotal) =>
            {
                // Note here the ref
                Add(person, ref subtotal);
                return subtotal;
            },
            finalResult => Interlocked.Add(ref total, finalResult)
        );
        Console.WriteLine(total);
        Console.ReadKey();
    }
    public static void Add(Person person, ref int shared)
    {
        // Do some work
        shared = +person.Age;
    }
