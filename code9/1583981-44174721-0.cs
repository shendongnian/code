    static IEnumerable<string> generate(string s)
    {
        yield return new Regex("e").Replace(s, "", 1);
    
        yield return new Regex("aaaa").Replace(s, "e", 1);
        yield return new Regex("aa").Replace(s, "bb", 1);
        yield return new Regex("ba").Replace(s, "abbb", 1);
    
        yield return new Regex("bb").Replace(s, "aa", 1);
        
        var seq =
            ZipMany(new[]
                {
                    generate(new Regex("e").Replace(s, "", 1)),
                    generate(new Regex("aaaa").Replace(s, "e", 1)),
                    generate(new Regex("aa").Replace(s, "bb", 1)),
                    generate(new Regex("ba").Replace(s, "abbb", 1)),
                    generate(new Regex("bb").Replace(s, "aa", 1))
                },
                elts => elts).SelectMany(items => items);
        
        foreach (var elt in seq) yield return elt;
    }
