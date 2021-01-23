    bool CheckIfAllIntersect(IEnumerable<Rect> rectangles)
    {
        return rectangles.Aggregate(rectangles.FirstOrDefault(), Rect.Intersect) != Rect.Empty;
    }
    
    
    bool CheckIfAnyInteresect(IEnumerable<Rect> rectangles) 
    {
        return rectangles.Any(rect => rectangles.Where(r => !r.Equals(rect)).Any(r => r.IntersectsWith(rect)));
    }
