    class Program
    {
        static void Main(string[] args)
        {
            string s = "acn";
            foreach (var permutation in s.Permutations())
                Console.WriteLine(string.Concat(permutation));
        }
    }
