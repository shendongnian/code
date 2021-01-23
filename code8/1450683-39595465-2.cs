    // create DataSet
    DataSet ds = new DataSet();
    
    // your operations for filing the DataSet with data from the database which you have not shared
    // ...
    // ...
    
    // check to see whether we have a DataTable in the DataSet (if the query fails, ds.Tables.Count == 0)
    if (ds.Tables.Count > 0) {
       DataRow row = ds.Tables[0].NewRow();
       // add data according to the schema
       // e.g.
       row["id"] = "blah";
       // add the rest of the columns
    
       // and lastly add the newly created row to the DataTable;
       ds.Tables[0].Rows.Add(row);
    }
    
    // now bind
    GridViewRecord.DataSource = ds.Tables[0];
    GridViewRecord.DataBind();
