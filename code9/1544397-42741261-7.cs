    public static DestinationObject MapSourceToDestinationIter(SourceObject source)
    {
        var result = new DestinationObject();
        result.Id = source.Id;
        if (source.Children.Count == 0)
        {
            return result;
        }
        List<int> cycleTot = new List<int>();
        List<int> cycleRef = new List<int>();
        cycleRef.Add(0);
        cycleTot.Add(source.Children.Count-1);
        do
        {
            var curr = source.GetAtList(cycleRef);
            result.SetAtList(cycleRef, curr);
            if (curr.Children.Count == 0)
            {
                cycleRef[cycleRef.Count - 1]++;
                while (cycleRef[cycleRef.Count - 1]> cycleTot[cycleTot.Count-1])
                {
                    cycleRef.RemoveAt(cycleRef.Count - 1);
                    cycleTot.RemoveAt(cycleTot.Count - 1);
                    if (cycleRef.Count == 0)
                    {
                        break;
                    }
                    cycleRef[cycleRef.Count - 1]++;
                } 
            } else
            {
                cycleRef.Add(0);
                cycleTot.Add(curr.Children.Count - 1);
            }
        } while (cycleTot.Count>0);
        return result;
    }
