    public static int[] processFunc(int[] scores, int[] l, int[] r)
    {
        HashSet<int> lAndR = new HashSet<int>(l);
        foreach (var i in r)
        {
            lAndR.Add(i);
        }
    
        var grouped = scores.Where(z => lAndR.Contains(z)).GroupBy(z => z).ToDictionary(val => val.Key, val => val.Count());
    
        return l.Zip(r, (left, right) => grouped[left] + grouped[right]).ToArray();
    }
