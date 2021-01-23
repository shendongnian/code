        List<DataView> dvTablesLookup = new List<DataView>();
        List<DataTable> dtTablesLookup = new List<DataTable>();
        // Creating Data View
        for (int i=0; i < datatablesLookup.Count; i++ )
        {
            DataView tempdv = new DataView(datatablesLookup[i]);
            tempdv.Sort = sortLookup;
            dvTablesLookup.Add(tempdv);                
            dtTablesLookup.Add(tempdv.ToTable());
        }
