    public static void Main(string[] args)
    {
        Random numGen = new Random();
        int success = 0, successiveAttempts = 0, tries = 10000;
        for( int  x = 0; x < tries; x++)
        {
            successiveAttempts = (numGen.Next(1, 7)== 6) ? successiveAttempts + 1 : 0;
            if(successiveAttempts > 1) 
                success++;
        }
        Console.WriteLine("{0} successive roles of 6 in {1} tries.", success, tries);
        Console.WriteLine("Ratio is {0}", tries/success);
    }
