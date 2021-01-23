    public override string ToString()
    {
        StringBuilder s = new StringBuilder();
        for (int i = 0;i < mTable.Length; i++)
        {
            if (mTable[i].Status == EntryType.Active)
            {
                // Use s.Append() or s.AppendFormat() to build up your string
            }
        }
        return s.ToString();
    }
