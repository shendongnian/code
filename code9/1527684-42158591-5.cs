    public static bool HasOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
    {
        return Min(start1, end1) < Max(start2, end2) && Max(start1, end1) > Min(start2, end2);
    }
    public static DateTime Max(DateTime d1, DateTime d2)
    {
        return d1 > d2 ? d1 : d2;
    }
    public static DateTime Min(DateTime d1, DateTime d2)
    {
        return d2 > d1 ? d1: d2;
    }
