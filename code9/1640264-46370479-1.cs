    public bool IsDrawingOverAllowed(LayoutPointer pointer)
    {
        if (pointer == null) 
        {
            Debug.LogWarning("IsDrawingOverAllowed: Pointer is null!");
            return true; // or false, it depends on your design..
        }
        if (!pointer.IsValid()) // <-- I also like early returns :D 
        {
            return true;
        }
        var leadingTrailSegment = pointer.GetLeadingTrailSegment()
        return !midline.IsParallelTo(leadingTrailSegment);
    }
