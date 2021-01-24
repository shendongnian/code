    public class SearchableFile {
        private readonly HashSet<string> _uniqueLines;
        //private readonly HashSet<string> _uniqueString;
        public string FilePath { get; }
        public SearchableFile(string filePath) {
            _uniqueLines = new HashSet<string>(File.ReadAllLines(filePath));
            //↑You can also split each line if you have many repeating words in each line.
            //_uniqueString = File.ReadAllLines(filePath).SelectMany(singleLine => singleLine.Split(' '));
            FilePath = filePath;
        }
        public bool ContainsCompositeString(string compositeString) {
            return _uniqueLines.Any(singleLine => singleLine.Contains(compositeString));
            //return _uniqueString.Contains(compositeString);
        }
    }
