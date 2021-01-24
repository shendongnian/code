    private static void Main()
    {
        List<string[]> loggBok = new List<string[]> {};
        DateTime tiden = DateTime.Now;
        Console.WriteLine(tiden);
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n\tVälkommen till loggboken!");
            Console.WriteLine("\t[1]Skriv ett inlägg: ");
            Console.WriteLine("\t[2]Skriv ut alla inlägg");
            Console.WriteLine("\t[3]Sök inlägg");
            Console.WriteLine("\t[4]Avsluta programmet!");
            Console.Write("\nVälj meny: ");
            int nr;
            while (!int.TryParse(Console.ReadLine(), out nr) || nr < 1 || nr > 4)
            {
                Console.Write("Försök igen, välj mellan 1-4: ");
            }
            switch (nr)
            {
                case 1:
                    Console.WriteLine("Skriv en titel till ditt inlägg: ");
                    string[] post = new string[2];
                    post[0] = Console.ReadLine();
                    Console.WriteLine("Skriv ett inlägg: ");
                    post[1] = Console.ReadLine();
                    loggBok.Add(post);
                    break;
                case 2:
                    Console.WriteLine("\nHär är dina inlägg i loggboken:\n ");
                    foreach (string[] text in loggBok)
                    {
                        Console.WriteLine("Inlägg:{0} " + "\n\t{1}", text[0], text[1]);
                    }
                    break;
                case 3:
                    Console.WriteLine("Skriv in ett ord för att söka bland dina inlägg");
                    string keyword = Console.ReadLine();
                    foreach (string[] text in loggBok)
                    {
                        if (text[0].Contains(keyword) || text[1].Contains(keyword))
                        {
                            Console.Write("\nTitel: " + text[0] + "\n" + text[1]);
                        }
                    }
                    break;
                case 4:
                    isRunning = false;
                    break;
            }
        }
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
