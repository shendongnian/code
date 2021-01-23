    public static void Main(string[] args)
    {
        string text = "xfoofoobarbar fooxxfoo barxxxfoo";
        var allSubstrings = Enumerable.Range(2,text.Length-2)
            .Select(x => {
                    var longestSub = FindSubStrings(text,x).GroupBy(y => y).OrderByDescending(y => y.Count()).FirstOrDefault();
                    return new Substrings {
                        Length = x,
                        Count = longestSub.Count(),
                        Value = longestSub.Key
                    };
            });
        
        foreach(var item in allSubstrings)
        {
            Console.WriteLine(item.Length + ":" + item.Count + ":" + item.Value);
        }
        
        var best = allSubstrings.Where(x => x.Count>1).OrderByDescending(x => x.Length).ThenByDescending(x => x.Count).First();
        
        Console.WriteLine("Longest, most frequest substring is " + best.Value);
    }
    
    public class Substrings
    {
        public int Length{get;set;}
        public int Count{get;set;}
        public string Value{get;set;}
    }
    
    private static IEnumerable<string> FindSubStrings(string input, int length)
    {
        for(var i=0;i<input.Length-length;i++)
        {
            yield return input.Substring(i,length);
        }
    }
