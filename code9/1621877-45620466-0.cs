    string input = "Hyundai Motor Company 현대자동차 现代 Some other English words";
    
    string englishCharsPattern = "[\x00-\x7F]+";
    var englishParts = Regex.Matches(input, englishCharsPattern)
                            .OfType<Match>()
                            .Where(m => !string.IsNullOrWhiteSpace(m.Groups[0].Value))
                            .Select(m => m.Groups[0].Value.Trim())
                            .ToList();
    
    string nonEnglishCharsPattern = "[^\x00-\x7F]+";
    var nonEnglishParts = Regex.Matches(input, nonEnglishCharsPattern)
                                .OfType<Match>()
                                .Select(m => m.Groups[0].Value)
                                .ToList();
    
    var finalParts = englishParts;
    finalParts.AddRange(nonEnglishParts);
    
    Console.WriteLine(string.Join(",", finalParts.ToArray()));	
