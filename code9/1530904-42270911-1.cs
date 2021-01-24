    public static IEnumerable<string> EnumerateAllPaths(string[] input)
    {
        var hs = new HashSet<string>();
        
        foreach(var s in input)
        {
            var parts = s.Split(new[]{@"\"},StringSplitOptions.None);
            
            for(var i = 0;i<parts.Length;i++)
            {
                var section = String.Join(@"\", parts.Take(i+1));
                if(hs.Add(section))
                    yield return section;
            }
                                
        }
    }
