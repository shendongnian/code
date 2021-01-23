    static void Main(string[] args)
    {
        int i, j, a, b;
        string k;
        Console.WriteLine("Enter the number of sets to be used: ");
        i = Convert.ToInt32(Console.ReadLine());
        for (j = 1; j <= i; j++)
        {
            SortedSet<string> set = new SortedSet<string>();
            var index = 0;
            do
            {
                index++;
                Console.WriteLine($"Enter {index} element in set {j}:");
                k = Console.ReadLine();
                if (k != "stop")
                    set.Add(k);
            } while (k != "stop");
            _items.Add(set);
        }
        if (_items.Count == 0)
        {
            Console.WriteLine("You have no sets to union.");
            return;
        }
        if (_items.Count == 1)
        {
            Console.WriteLine("Union of only set is: " + string.Join("", _items[0]));
            return;
        }
        while (true)
        {
            Console.WriteLine("Enter index of 1st set  of union:{0}");
            a = Convert.ToInt32(Console.ReadLine());
            if (a < _items.Count)
            {
                break;
            }
            Console.WriteLine($"Set {a} does not exists.");
        }
        while (true)
        {
            Console.WriteLine("Enter index of 2nd set  of union:{0}");
            b = Convert.ToInt32(Console.ReadLine());
            if (b < _items.Count)
            {
                break;
            }
            Console.WriteLine($"Set {b} does not exists.");
        }
