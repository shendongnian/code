    public bool GetLeadingTrailSegment()
    {
        if (!IsValid()) 
        {
            return Vector3.zero;
        }
    
        return (lead - _line.GetPosition(_line.positionCount - 2));
    }
