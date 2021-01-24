    class Program
    {
        private class MyEqualityComparer : EqualityComparer<int>
        {
            public override bool Equals(int x, int y)
            {
                return x == y;
            }
            public override int GetHashCode(int obj)
            {
                return obj.GetHashCode();
            }
        }
        static void Main(string[] args)
        {
            var comparer = HashSet<int>.CreateSetComparer();
            var set1 = new HashSet<int>(new MyEqualityComparer()) { 1 };
            var set2 = new HashSet<int> { 1, 2 };
            Console.WriteLine(comparer.Equals(set1, set2));
            Console.WriteLine(comparer.Equals(set2, set1)); //True!
            Console.ReadKey();
        }
    }
