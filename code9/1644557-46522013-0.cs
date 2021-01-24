    string Sanitize(string line)
    {
        if(!Regex.IsMatch(line, @"""[^""]*"))
            return line;
        string pattern = @"\s+|"""; // <-- match multiple spaces or " character
        Regex regex = new Regex(pattern, RegexOptions.Multiline);
        string replacement = @" ";
        // replace matched strings with a single space
        var replaced = regex.Replace(line, replacement);
        // since " at the beginning and end of the string 
        // are replaced by spaces, trim those spaces before returning
        return replaced.Trim();
    }
