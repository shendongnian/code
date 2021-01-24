    public class WordDictionary: {
        private static List<string> _wordList = new Dictionary<string> ();
        static WordDictionary() {
            _wordList.Add ("Bad");
        }
        public static Contains(string word) {
            return _wordList.Contains(word);
        }
        public static ContainsAny(IEnumerable<string> words) {
            return words.Any(w => Contains(w));
        }
    }
