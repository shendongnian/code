    string NextInString(string listOfNames, string userName)
    {
        if(listOfNames == string.Empty || userName == string.Empty) return string.Empty;
    
        var names = listOfNames.Split(',');
        return names
            .SkipWhile(x => x != userName)
            .Skip(1)
            .FirstOrDefault() ?? names.Last();
    }
