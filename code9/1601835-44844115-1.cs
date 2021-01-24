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
    
    stp.Restart();
    //Foreach approach
    qaList = new List<QuestionAnswer>();
    foreach (var item in valuesDict)
    {
        qaList.Add(new QuestionAnswer { Question = item.Key, Answer = item.Value });
    }
    stp.Stop();
    Console.WriteLine(stp.ElapsedTicks);
