    var numbers = new List<string>
                                       {
                                           "988",
                                           "1234567",
                                           "988448484",
                                           "62615",
                                           "6261545"
                                       };
    
                foreach(var s in numbers)
                {
                    if(numbers.Any(x=>x.StartsWith(s) && x != s))
                        Console.WriteLine(s);
                }
