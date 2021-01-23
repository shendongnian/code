    string text = "xfoofoobarbar fooxxfoo barxxxfoo";
    var allSubstrings = Enumerable.Range(2,text.Length)
                .ToDictionary(k => k,v => FindSubStrings(text,v));
    ...
    IEnumerable<string> FindSubStrings(string input, int length)
    {
        for(var i=0;i<input.Length-length;i++)
        {
            yield return input.Substring(i,length);
        }
    }
