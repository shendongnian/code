    public DataTable GetSampleDatatable() 
    {    
        OracleDataTable myDataTable = new OracleDataTable(sqlStr, this);
        myDataTable.FetchAll = true;
        myDataTable.Active = true;
        return myDataTable;
    }
