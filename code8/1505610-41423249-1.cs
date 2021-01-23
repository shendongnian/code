                string inputString = "it was one ";
                var numbList = new List<string> { "zero", "one", "two" };
                if (numbList.Any(x => inputString.Contains(x)))
                {
                    if (numbList.Any(x => inputString.Trim().StartsWith(x) && inputString.Trim().EndsWith(x)))
                    {
                        Console.WriteLine("string contains list value");
                    }
                    else
                    {
                        Console.WriteLine("string contains list value and other words");
                    }
                }
                else
                {
                    Console.WriteLine("string does not contains list value");
                }
