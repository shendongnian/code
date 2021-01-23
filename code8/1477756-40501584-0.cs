        string pattern = @"(?<=\d)(?=[a-zA-Z])";
        string substitution = @" ";
        string input = @"""X 300g"", ""X 400 g"", ""X 250 kg"", ""X 25kg""";
        
        Regex regex = new Regex(pattern);
        string result = regex.Replace(input, substitution);
