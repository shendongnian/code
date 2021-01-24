    public static IEnumerable<string> EnumerateAllPaths(string[] input)
    {
        var hs = new HashSet<string>();
        
        foreach(var s in input)
        {
            var parts = s.Split(new[]{@"\"},StringSplitOptions.None).ToList();
            
            for(var i = 0;i<parts.Count;i++)
            {
                var section = String.Join(@"\", parts.Take(i+1));
                if(hs.Add(section))
                    yield return section;
            }
                                
        }
    }
