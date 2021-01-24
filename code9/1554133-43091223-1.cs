    DataTable dt = new DataTable();
    dt.Load(oledbcmd.ExecuteReader());
    SqlBulkCopy = newSqlBulkCopy(ssqlconnectionstring);
    bulkcopy.DestinationTableName = ssqltable;
    for(int i = 0; i < dt.Columns.Count; i++){
        bulkcopy.ColumnMappings.Add(i,i);
    }
    bulkcopy.WriteToServer(dt);
