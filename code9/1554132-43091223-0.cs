    DataTable dt = new DataTable();
    dt.Load(oledbcmd.ExecuteReader());
    SqlBulkCopy = newSqlBulkCopy(ssqlconnectionstring);
    bulkcopy.DestinationTableName = ssqltable;
    bulkcopy.WriteToServer(dt);
