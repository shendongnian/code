    while (!result)
            {
                if (result)
                {
                    Console.Write("Valid Value");
                }
                else
                {
                    Console.Write("Please Enter A Valid Integer Value");
                    Console.WriteLine();
                    inputcost = Console.ReadLine();
                    result = int.TryParse(inputcost, out validcost);
                }
    
            }
