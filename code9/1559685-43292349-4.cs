    public class FirstOccurances
    {
        private HashSet<string> _wordSet;
        
        public FirstOccurances(IEnumerable<string> wordKeys)
        {
            _wordSet = new HashSet<string>(wordKeys);
        }
        public List<bool> GetFor(List<string> words)
        {
            return words.Select(word => _wordSet.Contains(word)).ToList();
        }
    }
