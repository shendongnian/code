        static void Main(string[] args)
        {
            string word = string.Empty; 
            string reverse = string.Empty;
            Console.WriteLine("type any word to check if it palindrome or not");
            word = Console.ReadLine();
            var sb = new StringBuilder();
            for (var i = word.Length - 1; i >= 0; i--)
            {
                var ch = word[i];
                sb.Append(word[i]);
            }
            reverse = sb.ToString();
            Console.WriteLine(word);
            Console.WriteLine(reverse);
            Console.ReadKey();
        }
    
