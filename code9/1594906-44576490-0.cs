        static void Main(string[] args)
        {
            string longTweet = @"Long sentence #With #Some schools like #AzharSchool and spread out
    over two #StPaulSchool lines ";
            string result = Regex.Replace(longTweet, @"\#\w+", match => ReplaceHashTag(match.Value), RegexOptions.Multiline);
            Console.WriteLine(result);
        }
        private static string ReplaceHashTag(string input)
        {
            switch (input)
            {
                case "#StPaulSchool": return "St. Paul School";
                case "#AzharSchool": return "Azhar School";
                default:
                    return input; // hashtag not recognized
            }
        }
