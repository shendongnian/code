    var numRollDices = int.Parse(Console.ReadLine());;
    var randomGenerator = new Random();
    var result = Enumerable
                    .Range(0, numRollDices)
                    .Select(i => randomGenerator.Next(1, 7))
                    .GroupBy(n => n)
                    .Select(n => new
                                {
                                    Num = n.First(),
                                    Count = n.Count(),
                                    Percentile = ((n.Count() * 100) / numRollDices)
                                });
    Console.WriteLine(string.Join($"{Environment.NewLine}", result.ToList()));
