    public Segment currentSegment;
    public List<Segment> segments;
    void OnEndReached()
    {
        //Put the completed segmetn back in the list ... probably at the end or randomized anywhere but at the start
        segments.Insert(segments.Count-1, currentSegment);
        //Now get the next segment
        currentSegment = segments[0];
        segments.RemoveAt(0);
    }
