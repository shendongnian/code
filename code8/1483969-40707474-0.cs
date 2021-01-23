        Console.Write("Ievadiet pirma masīva izmeru: ");
        int first = Convert.ToInt32(Console.ReadLine());
        string[] n = new string[first];
        Console.Write("Ievadiet pirma masīva izmeru: ");
        int second = Convert.ToInt32(Console.ReadLine());
        string[] m = new string[second];
        for (int i = 0; i < n.Length; i++)
        {
            Console.Write("Ievadiet 1. masiva {0} vertibu: ", i);
            n[i] = Console.ReadLine();
        }
        for (int j = 0; j < m.Length; j++)
        {
            Console.Write("Ievadiet 2. masiva {0} vertibu: ", j);
            m[j] = Console.ReadLine();
        }
        for (int i = 0; i < n.Length; i++)
        {
            Console.WriteLine("1. masiva {0} vertiba ir: " + n[i], i);
        }
        for (int j = 0; j < m.Length; j++)
        {
            Console.WriteLine("2. masiva {0} vertiba ir: " + m[j], j);
        }
        Console.Write("1. un 2. masīva apvienotā simbolu virkne: ");
        if (n.Length < m.Length)
        {
            for (int i = 0; i < n.Length; i++)
            {
                Console.WriteLine(n[i] + m[i]);
            }
            for (int i = n.Length; i < m.Length; i++)
            {
                Console.WriteLine(m[i]);
            }
        }
        else if (n.Length > m.Length)
        {
            for (int i = 0; i < m.Length; i++)
            {
                Console.WriteLine(n[i] + m[i]);
            }
            for (int i = m.Length; i < n.Length; i++)
            {
                Console.WriteLine(n[i]);
            }
        }
        else
        {
            for (int i = 0; i < n.Length; i++)
            {
                Console.WriteLine(n[i] + m[i]);
            }
        }
