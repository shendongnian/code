        List<DataView> dvTablesLookup = new List<DataView>();
        List<DataTable> dtTablesLookup = new List<DataTable>();
        // Creating Data View
        for (int i=0; i < datatablesLookup.Count; i++ )
        {
            dvTablesLookup[i] = new DataView(datatablesLookup[i]);
            dvTablesLookup[i].Sort = sortLookup;
            dtTablesLookup[i] = dvTablesLookup[i].ToTable();
        }
