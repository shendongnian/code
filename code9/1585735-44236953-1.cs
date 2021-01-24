        List<string> names = new List<string>();
        List<string> allreadyEntered = new List<string>();
        string naam;
        for(int i = 0;i<10;i++)
        {
            Console.WriteLine("Geef {0} naam in: ", i+1);
            naam = Console.ReadLine();
            
            if(names.Contains(naam) && !allreadyEntered.Contains(naam))
            {
                 allreadyEntered.Add(naam);
            }
            names.Add(naam);
        }
        foreach(string naam in allreadyEntered)
        {
            Console.WriteLine(naam);
        }
        Console.ReadLine();
