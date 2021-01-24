    var numbers = new int[] { 1, 5, 2, 3, 5 };
    int max = numbers.Max();
    var indexes = numbers.Select((c, i) => new 
                                           { 
                                              character = c, index = i 
                                           })
                         .Where(list => list.character == max)
                         .ToList();
