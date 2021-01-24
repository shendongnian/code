    public List<bool> getFirstOccurances(List<string> pwWords)
    {
        var wordSet = new HashSet<string>(WordsWithFDictionary.Keys);
        return pwWords.Select(word => wordSet.Contains(word)).ToList();
    }
