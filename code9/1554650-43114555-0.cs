    private static Dictionary<string, int>  dic=new Dictionary<string, int>()  ;
    public static void MinSum()
    {
      
        // here create statements where the key is a single letter
        dic.Add("a", 4);
        dic.Add("b", 6);
        dic.Add("c", 3);
        dic.Add("d", 4);
        dic.Add("e", 5);
        // here add the combination
        dic.Add("abcde", 8);
        dic.Add("abce", 10);
        dic.Add("ae", 2);
        
        var minSum= GetMinSum( "ae".ToCharArray());
        var minSum2 = GetMinSum("abc".ToCharArray());
        var minSum4 = GetMinSum("a".ToCharArray());
    }
    public static int GetMinSum(char[] letters)
    {
        //If the input is a single letter, then I simply return the value associated with that key
        if (letters.Count() == 1)
            return dic[letters[0].ToString()];
        // sumUp all the single Key elements
        var sumOfSingleKeyElements = dic.Where(x => x.Key.Length == 1 && letters.Contains(x.Key[0])).Sum(v => v.Value);
        // get the min value Key elements that combine the letters above
        //  the " !letters.Except(x.Key.ToCharArray()).Any()" defines if the set letters is a subset of the key
        var minOfCompositeKeyElements = dic.Where(x => x.Key.Length > 1 
                            && !letters.Except(x.Key.ToCharArray()).Any()
                            ).Min(v => v.Value);
                        
        return sumOfSingleKeyElements < minOfCompositeKeyElements ? sumOfSingleKeyElements : minOfCompositeKeyElements;
    }
