    public string readText()
            {
               string test = string.Empty;
               var mytext = File.ReadLines("C:\\temp\\test_search.txt")
                    .SkipWhile(line => !line.Contains("g_FffectNames[EFFECT_COUNT]"))
                    .Skip(1)
                    .TakeWhile(line => !line.Contains("};"));
    
                foreach (var line in mytext)
                {
                    test += line;
                }
    
                return test;
            }
