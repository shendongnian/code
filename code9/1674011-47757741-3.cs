    static void Main(string[] args)
    {
        int tulos = 0;
        for (int i = 0; i < 10; i++)
        {
            Console.Write("Anna kokonaisluku: ");
            string luku = Console.ReadLine();
            int annettu = int.Parse(luku);
            tulos += annettu;
        }
        Console.WriteLine("Lukujen summa on " + tulos);
        Console.ReadKey();
    }
