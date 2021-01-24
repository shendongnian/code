    var name = "Bob";
    var validTypes = new List<string> {"M", "W", "R"};
    while (true)
    {
        Console.WriteLine($"Welcome {name}, please pick a class" +
                           "\n(M)age" +
                           "\n(W)arrior" +
                           "\n(R)ogue" +
                           "\n");
        var charType = Console.ReadLine();
                    
        if (validTypes.Contains(charType.ToUpper()))
        {
            break;
        }
        else
        {
            Console.WriteLine("Please enter a valid class letter");
        }
