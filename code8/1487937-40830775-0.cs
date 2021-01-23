    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tVälkommen till Ryggsäcken!!\n");
            Console.WriteLine("\t[1] Lägg till ett föremål i det stora facket");
            Console.WriteLine("\t[2] Lägg till ett föremål i ytterfacket");
            Console.WriteLine("\t[3] Skriv ut innehållet i stora facket");
            Console.WriteLine("\t[4] Skriv ut innehållet i ytterfacket");
            Console.WriteLine("\t[5] Rensa innehållet i stora facket");
            Console.WriteLine("\t[6] Rensa innehållet i ytterfacket");
            Console.WriteLine("\t[7] Avsluta\n");
            string[] ytterFack = new string[4];
            List<string> storaFacket = new List<string> { };
            int i = 0;
            bool kör = true;
            do 
            {
                Console.Write("\n\tVälj punkt från menyn: ");
                int menyVal = Convert.ToInt32(Console.ReadLine());
                switch (menyVal) 
                {
                    case 1:
                        Console.Write("\n\tSkriv in ett föremål: ");
                        storaFacket.Add(Console.ReadLine());
                        //Console.WriteLine("\n\tDu har lagt in " +  + " Tack!\n");
                        break;
                    case 2:
                        Console.Write("\n\tSkriv in ett föremål: ");
                        if (ytterFack[0] == null)
                        {
                            ytterFack[0] = Console.ReadLine();
                            break;
                        }
                        else if (ytterFack[1] == null)
                        {
                            ytterFack[1] = Console.ReadLine();
                            break;
                        }
                        else if (ytterFack[2] == null)
                        {
                            ytterFack[2] = Console.ReadLine();
                            break;
                        }
                        else if (ytterFack[3] == null)
                        {
                            ytterFack[3] = Console.ReadLine();
                            break;
                        }
                        else if (ytterFack[4] == null)
                        {
                            ytterFack[4] = Console.ReadLine();
                            break;
                        }
                        break;
                        
                    case 3:
                        Console.WriteLine("\tInnehållet i stora facket är:");
                        foreach (string item in storaFacket)
                        {
                            Console.WriteLine("\t" + item);
                        }
                        break;
                    case 4:
                        Console.WriteLine("\tInnehållet i ytterfacket är:");
                        foreach (string item in ytterFack)
                        {
                            Console.WriteLine("\t" + item);
                        }
                        break;
                    case 5:
                        storaFacket.Clear();
                        Console.WriteLine("\tNu är stora facket tömt!\n");
                        break;
                    case 6:
                        Array.Clear(ytterFack, 0, ytterFack.Length);
                        Console.WriteLine("\tNu är ytterfacket tömt!\n");
                        break;
                    case 7:
                        kör = false;
                        break; 
                    default:
                        break;
                }
            }
            while (kör);
        }
    }
}
