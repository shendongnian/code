    Console.WriteLine("Please enter the month in numerical value (1-        12)");
                    if (!Int32.TryParse(Console.ReadLine(), out result))
                    {
                        result = 0;
                    }
                    Console.Write(result);
