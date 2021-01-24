        String pattern = "( +)";
        String substitution = "$1 ";
        String input = "a b  c   d    e";
        RegexOptions options = RegexOptions.Multiline;
        
        Regex regex = new Regex(pattern, options);
        string result = regex.Replace(input, substitution);
