    class Program
    {
        static void Main(string[] args)
        {
            const string abc = "asduqwezxc";
            foreach (var vowel in abc.SelectOnlyVowels())
            {
                Console.WriteLine("{0}", vowel);
            }
            Console.ReadLine();
        }
    }
    public static class StringManipulation
    {
        public static string SelectOnlyVowels(this string text)
        {
            var vowels = new List<string> { "a", "e", "i", "o", "u" };
            var result = "";
            foreach (char c in text.ToCharArray())
            {
                if (vowels.Contains(c.ToString()))
                {
                    result += c;
                }
            }
            return result;
        }
    }
