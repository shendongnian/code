    public int FindIndexByDataField(this GridView gv, string datafieldname)
    {
        int index = -1, cnum = 0;
        foreach (DataControlField col in gv.Columns)
        {
            if (col is BoundField)
            {
                BoundField coll = (BoundField)gv.Columns[cnum];
                if (coll.DataField == datafieldname)
                {
                    index = cnum;
                    break;
                }
            }
            cnum++;
        }
        return index;
    }
