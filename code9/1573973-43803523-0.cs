    string dictionaryFileName = @"C:\Test\SampleDictionary.txt"; // replace with your file path
    string searchedTerm = "Cat"; // Replace with user input word
    string searchRegex = string.Format("^(?<Term>{0});(?<Lang>[^;]*);(?<Desc>.*)$", searchedTerm);
    string foundTerm;
    string foundLanguage;
    string foundDescription;
    using (var s = new StreamReader(dictionaryFileName, Encoding.UTF8))
    {
        string line;
        while ((line = s.ReadLine()) != null)
        {
            var matches = Regex.Match(line, searchRegex, RegexOptions.IgnoreCase);
            if (matches.Success)
            {
                foundTerm = matches.Groups["Term"].Value;
                foundLanguage = matches.Groups["Lang"].Value;
                foundDescription = matches.Groups["Desc"].Value;
                break;
            }
        }
    }
