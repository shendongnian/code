       foreach (string check in myList)
                {
                    if (longString.Any(str => longString.Contains(check)))
                    {
                        Console.WriteLine("success!");
                    }
                    else
                    {
                        Console.WriteLine("fail!");
                    }
                }
