        ...
        DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        // iterate each sheet
        foreach (System.Data.DataRow sheet in dtSheet.Rows)
        {
            string sheetName = sheet["table_name"].ToString();
            cmd.CommandText = "select * from [" + sheetName + "]";
            da.SelectCommand = cmd;
            da.Fill(dt);
            using (OleDbDataReader dReader = cmd.ExecuteReader())
            {
                using (SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection))
                {
                    // Give your Destination table name.  Table name is sheet name minus any $
                    sqlBulk.DestinationTableName = sheetName.Replace("$", "");
                    sqlBulk.WriteToServer(dReader);
                    conn.Close();
                }
            }
        }
    }
