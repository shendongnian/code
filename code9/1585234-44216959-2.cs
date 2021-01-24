                public DataTable ProcessTable(DataTable _tbl)
                {
                    //copy the schema to new datatable
    
                    var query = from r1 in _tbl.AsEnumerable()
                                join r2 in _tbl.AsEnumerable() on r1.Field<string>("StartLoc") equals r2.Field<string>("EndLoc")
                                select new { r1 = r1, r2 = r2 };
    
                    DataTable processedTable = query.Where(x => x.r1.Field<int>("Distance") < x.r2.Field<int>("Distance"))
                                                     .Select(x => x.r1)
                                                     .CopyToDataTable(); 
    
                    return processedTable;
                }
