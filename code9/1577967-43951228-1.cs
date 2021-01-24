    var inputList = new List<string>() { "Bananas!", "Cherry2", "Mango","Apples", "Grape$", "Guava" };
                    
    var outputList = inputList.OrderBy(s => new string(Regex.Replace(s, "[^a-zA-Z]", "")
                                                            .Reverse()
                                                            .ToArray()))
                              .ToList();
    var output = String.Join("~", outputList);
