       SqlBulkCopy copy = new SqlBulkCopy(con, SqlBulkCopyOptions.KeepIdentity, transaction);
       //you can define any Banch of Data insert
       copy.BatchSize(10000);
       copy.DestinationTableName = "SampleCSV";
       copy.WriteToServer(table);
       transaction.Commit();
       con.Close();
