    private static IEnumerable<int> GetEnumerable()
    {
        Console.WriteLine("~~~ GetEnumerable Start");
        foreach (int i in new[]{3, 2, 1})
        {
            Console.WriteLine(">>> yield return : " + i);
            yield return i;
        }
    
        Console.WriteLine("~~~ GetEnumerable End");
    }
