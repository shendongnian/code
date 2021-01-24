        class Program
        {
    
            static void Main(string[] args)
            {
                string text = "This:is~a>test";
                string subject = text.ReplaceFromCollection(new char[] { ':', '~', '>'}); //symbol list, like ":", "~", ">"
                  
                Console.WriteLine($"{text}\n{subject}");
                Console.ReadLine();
            }
            
        }
    
        static class Extensions
        {
            public static String ReplaceFromCollection(this string text, IEnumerable<char> characters)
            {
                foreach (var chr in characters)
                {
                    text = text.Replace(chr.ToString(), String.Empty);
                }
                return text;
            }
        }
    
