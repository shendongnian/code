    namespace String_Length
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Give 1. word >");
            string word1 = Console.ReadLine();
            Console.Write("Give 2. word >");
            string word2 = Console.ReadLine();
            CompareStrings(word1, word2);   
        }
        static void CompareStrings(string one, string two)
        {
            if (one.Length > two.Length)
            {
                Console.Write("String One is longer.");
            }
            else
            {
                Console.Write("String Two is longer.");
            }
        }
    }
