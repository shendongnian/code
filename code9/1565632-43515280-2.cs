    private static Dictionary<char, double> Letters = new Dictionary<char, double>()
    {
       {'A', 1.5}, {'C', 3.9}, {'R', 3.1}, 
    };
    private static double CalculateScore(string word)
    {
        double result = 0;
        foreach(var c in word)
        {
           var upperChar = char.ToUpperInvariant(c);
           if(Letters.ContainsKey(upperChar)
           {
              result += Letters[upperChar];
           }                      
        }
 
        return result;
    }
