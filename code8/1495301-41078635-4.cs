    public static IEnumerable<string> GetNthEnumeration(IEnumerable<string> baseEnumeration, int n)
    {
        if (baseEnumeration == null) throw new ArgumentNullException();
        if (n < 0) throw new ArgumentOutOfRangeException();
        if (n == 0) //base case
        {
            foreach (var item in baseEnumeration) { yield return item; }
        }
        else //build recursively
        {
            foreach (var pre in baseEnumeration) 
            {
                foreach (var post in GetNthEnumeration(baseEnumeration, n - 1))
                {
                    yield return pre + post; 
                }
            }
        }
     }
