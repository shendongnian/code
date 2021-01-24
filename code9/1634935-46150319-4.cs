    bool HasSame(DataTable w, DataTable b, DataTable t)
    {
        if((w.Rows.Count == b.Rows.Count && b.Rows.Count ==  t.Rows.Count) == false ) return false;
    
        var wHashSet = DataTableToHashSet (w, "Wfname");
        var bHashSet = DataTableToHashSet (b, "Bfname");
    
        if(!wHashSet.SetEquals(bHashSet))
            return false;
    
        var tHashSet = DataTableToHashSet (t, "Tfname");
    
        return tHashSet.SetEquals(wHashSet);
    }
    
    HashSet<string> DataTableToHashSet(DataTable dt, string fieldName)
    {
        return new HashSet<string>(dt.AsEnumerable().Select (dr =>
                                     	Path.GetFileNameWithoutExtension( dr[fieldName].ToString())
                                   ));
    }
