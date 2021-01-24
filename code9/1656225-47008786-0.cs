    using (var command = new SqlCommand("SELECT COUNT(*) FROM Device_GameDevice", sqlConn, transaction) { CommandType = CommandType.Text })
                                    {
     SqlBulkCopyColumnMapping mapstep = new SqlBulkCopyColumnMapping("Message", "Message");
      SqlBulkCopyColumnMapping maptran = new SqlBulkCopyColumnMapping("DeviceName", "DeviceName");
     SqlBulkCopyColumnMapping mapstt = new SqlBulkCopyColumnMapping("dt_datetime", "dt_datetime");
     SqlBulkCopyColumnMapping mapfunc = new SqlBulkCopyColumnMapping("GameName", "GameName");
    
     sqlBulk.ColumnMappings.Add(mapstep);
     sqlBulk.ColumnMappings.Add(maptran);
     sqlBulk.ColumnMappings.Add(mapstt);
     sqlBulk.ColumnMappings.Add(mapfunc);
                                       
     sqlBulk.DestinationTableName ="Device_GameDevice";
                                        
    sqlBulk.WriteToServer(resultantDataTableForMaxDate);
    command.ExecuteNonQuery();
    
    transaction.Commit();
     }
