    string[] Names = new string[] { "Sangeen Khan",
        "AABY", "AADLAND", "LAND", "LAND", "SANG",
        "jh", "han", "ngee", "SNOW", "Jhon Snow", "ADEMS", "RONALDO" };
    string Text = "I am Sangeen Khan and I am friend of AABY. Jhon\
        is also friend of AABY. AADLAND is good boy and he never speak\
        lie. AABY is also good. SANGEEN KHAN is my name.";
    var pattern = string.Join(Names
        .Select(s => string.Format(@"((?<=($|\W)){0}(?=(^|\W)))",
            Regex.Replace(s, @"(?<notletter>\W)", "[${notletter}]"))), "|");
    var regex = new Regex(pattern);
    var matchedWords = regex.Matches(Text).Select(s => s.Value).Distinct().ToList();
    int numMatchedWords = matchedWords.Count;
    Text = regex.Replace(Text, "Names");
    Console.WriteLine($"Matched Words: {matchedWords.ToString()}");
    Console.WriteLine($"Count: {numMatchedWords}");
    Console.WriteLine($"Replaced Text: {Text}");
