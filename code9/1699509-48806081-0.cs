    public static class CommonExtension
    {
        public static List<string> LastNItem(this string str, int nItem, string separator = ".")
        {
            var splittedWords = str.Split(new [] { separator }, StringSplitOptions.None);
            var res = splittedWords.Reverse().Take(nItem).Reverse().ToList();
    
            return res;
        }
    }
