    string input = "1.0, 1.1, 2.0, 2.1, 2.5,3.0, 3.7, 4.5, 4.6, 4.7, 5.9,6.2,6.7,7.1.7.2.7.3.7.4, 8.7, 8.8,10.1, 10.2, 10.2.1, 10.2.3";
    // Split at comma
    var temp = input.Split(',').Select(x => x.Trim());
    // Creates an IEnumerable with the string grouped for their initial value
    var result = Enumerable.Range(1, 10)
                            .Select(x => string.Join(",", 
                                temp.Where(c => c.StartsWith(x.ToString() + "."))));
    // Rejoin the strings in a single string excluding empty ones
    string final = string.Join(Environment.NewLine + "," , 
                          result.Where(x => !string.IsNullOrEmpty(x)));
    Console.WriteLine(final);
