    class Program
    {
        public class MyComparer : IComparer<char>
        {
            private readonly Dictionary<char, int> _sortOrder;
            public MyComparer()
            {
                // This is just an example of simple logic based on your question.
                // The idea is you encapsulate the data your compare routine needs inside a custom comparer type
                // In this simple example I have created a lookup based on the final order of the characters in your question
                _sortOrder = new Dictionary<char, int> { { 'B', 0 }, { 'A', 1 }, { 'C', 2 } };
            }
            public int Compare(char x, char y)
            {
                // Again, this is just an example of how your main compare routine might work
                // The key is that the sort logic goes inside this method
                var precedenceLeft = _sortOrder[x];  // My example is seriously brittle.  This will crash for any characters that are not 'A', 'B' or 'C'
                var precedenceRight = _sortOrder[y];
                return precedenceLeft.CompareTo(precedenceRight);
            }
        }
        static void Main(string[] args)
        {
            // This code can be improved in numerous ways; this is just a simple example
            var chars = "ABCCAB".ToCharArray().ToList();
            chars.Sort(new MyComparer());  // You then give your customer comparer to the usual sort method
            var result = new string(chars.ToArray());
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
