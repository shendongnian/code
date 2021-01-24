    public static SparseAList<double> GetNodeSrcRow3(string nodeName)
    {
        SparseAList<double> r = new SparseAList<double>();
        r.InsertSpace(0, cpaths.Count); // allocates zero memory.
        List<int> indexes;
        if(!_dictionary.TryGetValue(nodeName, out indexes)) return r;
 
        foreach(var index in indexes) r[index] = 1;
        
        return r;
    }
