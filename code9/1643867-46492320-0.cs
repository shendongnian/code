    public int GetIndexByName(this GridView gv, string headerName)
    {
        int index = -1, cnum = 0;
        foreach (DataControlField col in gv.Columns)
        {
            if (col is BoundField)
            {
                BoundField coll = (BoundField)gv.Columns[cnum];
                if (coll.HeaderText == headerName)
                {
                    index = cnum;
                    break;
                }
            }
            cnum++;
        }
        return index;
    }
