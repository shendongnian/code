    public List<bool> GetFor(List<string> words)
    {
        return words.AsParallel().Select(word => _wordSet.Contains(word)).ToList();
    }
    
