    static void Main(string[] args)
    {
        string stringfromfile = @"En;
                                15;
                                Vu;
                                US;
                                32;";
    
        string[] ar = stringfromfile.Split(';');
    
        if (ar.Contains("Vu"))
        {
            Console.WriteLine("TRUE");
        }
        else
        {
            Console.WriteLine("FALSE");
        }
    }
