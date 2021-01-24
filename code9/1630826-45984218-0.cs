    public static Dictionary<string,Dictionary<string,bool>> AnalyzeFiles(IEnumerable<string> files, IEnumerable<string> dependencies)
    {
        var filesAnalyzed = ( from item in files.AsParallel()
                              let result=AnalyzeFile(item, dependencies)
                              select (Item:item,Result:result)
                            ).ToDictionary( it=>it.Item,it=>it.Result)               
        return filesAnalyzed;
    }
