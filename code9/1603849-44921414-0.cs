    string input = "Teste teste "; 
    var values = Encoding.ASCII.GetBytes(input);
    foreach(var item in values)
    {
        Console.WriteLine(item);
    }
    Console.ReadLine();
