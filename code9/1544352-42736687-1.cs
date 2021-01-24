        var bc = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
        {
            DestinationTableName = "TestData",
            BatchSize = dt.Rows.Count
        };
        dbConn.Open();
        bc.WriteToServer(dt);
        dbConn.Close();
        bc.Close();
