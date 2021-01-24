    public static bool IsMyDateTimeBetweenOther(DateTime my1, DateTime my2, DateTime other1, DateTime other2)
    {
        var dl = new List<DateTime> {my1, my2, other1, other2};
        dl.Sort();
        return dl[1] == my1 && dl[2] == my2 || dl[1] == my2 && dl[2] == my1;
    }
