    public static IEnumerable<string> Combs(string str, char c)
    {
        int count = str.Count(_c => _c == c);
        string _str = new string(str.Where(_c => _c != c).ToArray());
    
        // Compute all combinations with different positions
        foreach (var positions in GetPositionsSets(0, _str.Length, count))
        {
            StringBuilder _b = new StringBuilder();
            int index = 0;
            foreach (var _char in _str)
            {
                if (positions.Contains(index))
                { _b.Append($"{c}{_char}"); }
                else
                { _b.Append(_char); }
                index++;
            }
            if (positions.Contains(index))
                _b.Append(c);
            yield return _b.ToString();
        }
        //Compute the remaining combinations. I.e., those whose at some position
        //have the amount of supplied characters.
        string p = new string(c, count);
        for (int i = 0; i < _str.Length; i++)
        {
            yield return _str.Insert(i, p);
        }
        yield return _str + p;
    }
    
    //Gets all posible positions sets that can be obtain from minPos 
    //until maxPos with positionsCount positions, that is, C(n,k) 
    //where n = maxPos - minPos + 1 and k = positionsCount
    private static IEnumerable<HashSet<int>> GetPositionsSets(int minPos, int maxPos, int positionsCount)
    {
        if (positionsCount == 0)
            yield return new HashSet<int>();
    
        for (int i = minPos; i <= maxPos; i++)
        {
            foreach (var positions in GetPositionsSets(i + 1, maxPos,     positionsCount - 1))
            {    
                positions.Add(i);
                yield return positions;
            }
        }
    }
