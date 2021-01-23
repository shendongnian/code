    public static int GetMostUsedColor(Bitmap theBitMap)
    {
        TenMostUsedColors = new List<Color>();
        /*unchangeable code here*/
        return dctSortedByValueHighToLow.First().Value;
    }
