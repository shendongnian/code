    static void Main(string[] args)
    {
        string stringfromfile = @"En;
                                15;
                                Vu;
                                US;
                                32;";
    
        string[] ar = stringfromfile.Split('\n');
    
        for (int i = 0; i < ar.Length; i++)
        {
            ar[i] = ar[i].Replace(";","").Trim();
        }
    
        if (ar.Contains("Vu"))
        {
            Console.WriteLine("TRUE");
        }
        else
        {
            Console.WriteLine("FALSE");
        }
    
        Console.ReadLine();
    }
