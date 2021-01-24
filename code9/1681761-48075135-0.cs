    static void GetRowCol(long position, long colCount, out long row, out long col)
    {
        row = position / colCount;
        col = position % colCount;
    }
