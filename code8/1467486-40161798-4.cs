    while (!result)
    {
           Console.Write("Please Enter A Valid Integer Value");
           Console.WriteLine();
           inputcost = Console.ReadLine();
           result = int.TryParse(inputcost, out validcost);
                
     }
     Console.Write("Valid Value");
