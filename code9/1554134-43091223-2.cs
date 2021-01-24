    DataTable dt = new DataTable();
    dt.Load(oledbcmd.ExecuteReader());
    SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
    bulkcopy.DestinationTableName = ssqltable;
    for(int i = 0; i < dt.Columns.Count; i++){
        bulkcopy.ColumnMappings.Add(i,i);
    }
    bulkcopy.WriteToServer(dt);
