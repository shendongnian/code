    public class HighScore
    {
        static Dictionary<string, int> scoreBook = new Dictionary<string, int>()
        {
            { "Sam", 300 },
            { "Frodo", 200 },
            { "Bilbo", 100 },
        };
        public static void Main(string[] args)
        {
            AddScore("Gandolf", 250);
            foreach (var entry in GetTopScores())
            {
                Console.WriteLine("{0}: {1}", entry.Key, entry.Value);
            }
        }
        public static void AddScore(string name, int score)
        {
            scoreBook.Add(name, score);
        }
        public static IOrderedEnumerable<KeyValuePair<string, int>> GetTopScores()
        {
            var sortedScoreBook = from entry in scoreBook orderby entry.Value descending select entry;
            return sortedScoreBook;
        }
    }
