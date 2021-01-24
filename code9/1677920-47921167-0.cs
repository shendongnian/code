    var answer = Console.ReadLine();
    var sum = 0;
           
    while (answer != "x")
    {    
        if (Int32.TryParse(answer, out var value))
        {
            sum += value;
        }
        answer = Console.ReadLine();    
    }
    Console.WriteLine(sum);
