    int nomer2;
    string input = string.Empty;
    
    do
    {
        Console.WriteLine("Write Number");
        input = Console.ReadLine();
    }
    while (!int.TryParse(input, out nomer2)) ;
    
    Console.WriteLine("here is my Number {0}", nomer2);
