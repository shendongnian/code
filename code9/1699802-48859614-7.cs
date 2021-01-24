    public class WordDictionary: {
        private static Dictionary<string,bool> _wordDictionary = new Dictionary<string,bool> ();
        public static Dictionary<string, bool> Words {
            get { return _wordDictionary; }
        }
        static WordDictionary() {
            _wordDictionary.Add ("Bad",true);
        }
    }
