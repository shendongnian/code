    static void Main(string[] args)
    {
        int tulos = 0;
    
        for (int i = 0; i < 10; i++)
        {
            Console.Write("Anna kokonaisluku: ");
            string luku = Console.ReadLine();
            int annettu = int.Parse(luku);
     
            tulos = laske_pluslasku(tulos, annettu);
        }
        Console.WriteLine("Lukujen summa on " + tulos);
        Console.ReadKey();
    }
    static int laske_pluslasku(int tulos , int annettu)
    { 
        return tulos + annettu;
    }
