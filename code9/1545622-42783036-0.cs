    //  --- building up the data so the next (repeated) steps are efficient: ---
    // your words and points
    Dictionary<string, int> wordHolder = new Dictionary<string, int>();
    // create a dictionary where you can access all words and their points 
    // efficiently by the letters you have available:
    var efficientAccessByLetters = wordHolder.Select(entry => 
                                              new 
                                              {
                                                  Index = new string(entry.OrderBy(c => c)), 
                                                  Word = entry.Key,
                                                  Points = entry.Value
                                              })
                                              .GroupBy(x => x.Index)
                                              .ToDictionary(x => x.Key,
                                                            x => x.OrderBy(p => p.Points).ToList());
    //  --- Repeat this steps as many times as you like: ---
    // get letters that you want to build he best word from:
    var availableLetters = "aabceedope";
    // normalize the letters for fast index search by sorting them
    var normalized = new string(availableLetters.OrderBy(c => c));
    // need error handling here if it's not in there at all:
    // find all words and their respective points by index access
    var wordsThatMatchLetters = efficientAccessByLetters[normalized];
    // as words are sorted by points, just get the first
    var best = wordsThatMatchLetters.First();
    // output
    Console.WriteLine("Best Match: {0} for {1} points", best.Word, best.Points)
