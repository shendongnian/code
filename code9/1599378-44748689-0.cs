    using (Common.DbCommand cmd = conn.CreateCommand()) {
        cmd.CommandText = "MyProcName";
        dynamic dr = cmd.ExecuteReader();
        int index = 0;
        List<string> columns = new List<string>();
    
        for (index = 0; index <= dr.FieldCount - 1; index++) {
    /////
        }
    
    }
