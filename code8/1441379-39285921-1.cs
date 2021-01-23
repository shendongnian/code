    public static void Shuffle()
    {
        Random Rand = new Random();
        LinkedList<int> list = new LinkedList<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        foreach (int i in list)
            Console.Write("{0} ", i);
        Console.WriteLine();
        int size = list.Count;
         
        //Shuffle the list
        list =  new LinkedList<int>(list.OrderBy((o) =>
        {
            return (Rand.Next() % size);
        }));
        foreach (int i in list)
            Console.Write("{0} ", i);
        Console.WriteLine();
    }
