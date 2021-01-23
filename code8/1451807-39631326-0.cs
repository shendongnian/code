    List<int> Numbers = new List<int>();
    for (int i = 1; i <= 20; i++)
    {
        Numbers.Add(i);
    }
    IEnumerable<int> AcceptedNumbers = Numbers.Where(N => N.ToString().Distinct().Count() == N.ToString().Length);
    foreach (int AcceptedNumber in AcceptedNumbers)
    {
        Console.WriteLine(AcceptedNumber);
    }
