    public static void CallingMethod(IList<IRecord> recordList)
    {
        foreach (var item in recordList)
        {
            if (item is RecordA)
            {
                DoStuff((RecordA)item);
            }
            elseif (item is RecordB)
            {
                DoStuff((RecordB)item);
            }
        }
    }
