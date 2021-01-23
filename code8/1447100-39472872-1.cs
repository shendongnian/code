    string sample = "Foe Doe";
            
    var letterCounter = sample.ToLower().Where(letter => !char.IsWhiteSpace(letter))
                                        .GroupBy(letter => letter);
    
    foreach(var counter in letterCounter)
    {
        Console.WriteLine(String.Format("{0} = {1}", counter.Key, counter.Count()));
    }
