    static void Main(string[] args)
    {
        int tulos = 0;
        for (int i = 0; i < 10; i++)
        {
            Console.Write("Anna kokonaisluku: ");
            String Luku = Console.ReadLine();
            int annettu = int.Parse(Luku);
            tulos += annettu;
        }
        Console.WriteLine("Lukujen summa on " + tulos);
        Console.ReadKey();
    }
        
