    while (!result)
            {
                if (result == true)
                {
                    Console.Write("Valid Value");
                }
                else if (result == false)
                {
                    Console.Write("Please Enter A Valid Integer Value");
                    Console.WriteLine();
                    inputcost = Console.ReadLine();
                    result = int.TryParse(inputcost, out validcost);
                }
    
            }
