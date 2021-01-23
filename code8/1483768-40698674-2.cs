    // just a declaration without initialization
    public static Random Random; // <- the instance doesn't created
    
    ...
    {
    // Addressing Random which is null cause NullReferenceException 
    numberOne = Random.Next(0,11);
    numberTwo = Random.Next(0,6);
    
    Console.WriteLine(numberOne +" + "+ numberTwo);
    Console.ReadKey(true);
    }
