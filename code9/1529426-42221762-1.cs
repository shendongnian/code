    public static class StringExtensions
        {
            public static string ToTitleCase(this string s)
            {
    
            var upperCase = s.ToUpper();
            var words = upperCase.Split(' ');
    
            var minorWords = new String[] {"ON", "IN", "AT", "OFF", "WITH", "TO", "AS", "BY",//prepositions
                                       "THE", "A", "OTHER", "ANOTHER",//articles
                                       "AND", "BUT", "ALSO", "ELSE", "FOR", "IF"};//conjunctions
    
            var acronyms = new String[] {"UK", "USA", "US",//countries
                                       "BBC",//TV stations
                                       "TV"};//others
    
            //The first word.
            //The first letter of the first word is always capital.
            if (acronyms.Contains(words[0]))
            {
                words[0] = words[0].ToUpper();
            }
            else
            {
                words[0] = words[0].ToPascalCase();
            }
    
            //The rest words.
            for (int i = 0; i < words.Length; i++)
            {
                if (minorWords.Contains(words[i]))
                {
                    words[i] = words[i].ToLower();
                }
                else if (acronyms.Contains(words[i]))
                {
                    words[i] = words[i].ToUpper();
                }
                else
                {
                    words[i] = words[i].ToPascalCase();
                }
            }
    
            return string.Join(" ", words);
    
        }
    
        public static string ToPascalCase(this string s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();
        }
    }
