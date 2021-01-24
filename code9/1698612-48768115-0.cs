    static void Main(string[] args)
    {
        List<int> Primezahlen_Liste = new List<int>();
        int UnterGrenze=0;
        int UberGrenze=0;
        bool loop = false;
        while (!loop)
        {
            Console.Write("UnterGrenze:");
            loop = int.TryParse(Console.ReadLine(), out UnterGrenze);
            if(!loop)
                Console.WriteLine("Nur Integer Zahl bitte");
        }
        loop = false;
        while (!loop)
        {
            Console.Write("UberGrenze:");
            loop = int.TryParse(Console.ReadLine(), out UberGrenze);
            if (!loop)
                Console.WriteLine("Nur Integer Zahl bitte");
        }
        for (int Zahl = UnterGrenze; Zahl <= UberGrenze; Zahl++)
        {
            bool Zustand = true;
            if (Zahl == 2)
            {
                Zustand = true;
            }
            else if (Zahl == 1 || Zahl % 2 == 0)
            {
                Zustand = false;
            }
            else
            {
                for (int i = 3; i <= (int)Math.Sqrt(Zahl) + 1; i += 2)
                {
                    if (Zahl % i == 0)
                    {
                        Zustand = false;
                    }
                }
            }
            if (Zustand == true)
            {
                Primezahlen_Liste.Add(item: Zahl);
            }
        }
        string line = string.Join(",", values: Primezahlen_Liste.ToArray());
        Console.WriteLine(line);
        Console.WriteLine("Die Zahl der PreimZahlen in disem Bereich ist " + Primezahlen_Liste.Count);
        Console.WriteLine("Druecken Sie eine beliebige Taste . . .");
        Console.ReadLine();
    }
