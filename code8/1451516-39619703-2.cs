    var test = "AĄBCČDEĘĖFGHIĮYJKLMNOPRSŠTUŲŪVZŽ".Select(x => new string(x, 1)).ToArray();
    Console.OutputEncoding = System.Text.Encoding.Unicode;
    // Correct result because it uses the string comparer, which understands alphabetical order.
    test = test.OrderBy(x => x).ToArray();
    Console.WriteLine(string.Concat(test)); 
