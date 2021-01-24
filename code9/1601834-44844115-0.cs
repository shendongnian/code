    Dictionary<string, string> valuesDict = new Dictionary<string, string>();
    for (uint i = 0; i < 60000; i++)
    {
        valuesDict.Add(i.ToString(), i.ToString());
    }
    List<QuestionAnswer> qaList;
    Stopwatch stp = new Stopwatch();
    
    stp.Start();
    //LINQ approach
    qaList = valuesDict.Select(kv => new QuestionAnswer { Question = kv.Key, Answer = kv.Value }).ToList();
    stp.Stop();
    Console.WriteLine(stp.ElapsedTicks);
    
    stp.restart();
    //Foreach approach
    qaList = new List<QuestionAnswer>();
    foreach (var key in valuesDict.Keys)
    {
        qaList.Add(new QuestionAnswer { Question = key, Answer = valuesDict[key] });
    }
    stp.Stop();
    Console.WriteLine(stp.ElapsedTicks);
