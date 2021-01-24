    public static SourceObject GetAtList(this SourceObject s, List<int> cycleRef)
    {
        var ret = s;
        for (int i = 0; i < cycleRef.Count; i++)
        {
            ret = ret.Children[cycleRef[i]];
        }
        return ret;
    }
    public static void SetAtList(this DestinationObject d, List<int> cycleRef, SourceObject s)
    {
        var ret = d;
        for (int i = 0; i < cycleRef.Count - 1; i++)
        {
            ret = ret.Children[cycleRef[i]];
        }
        ret.Children.Add ( new DestinationObject() { Id = s.Id } );
    }
