    string input = Console.ReadLine();
    int maxValue;
    bool inputMatchesOne = textMaxValDictionary.TryGetValue(input, out maxValue);
    if(inputMatchesOne)
    {
       Console.Clear();
       int randIndex = rand.Next(0, maxValue);
       Console.WriteLine(joke[randIndex]);
       Discussion();
    }
    else
    {
        Console.WriteLine("Tell user that was wrong...");
    }
