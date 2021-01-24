    public long NextBaseline(DbContext context)
    {
        DataTable dt = new DataTable();
        var conn = context.Database.Connection;
        var connectionState = conn.State;
        try
        {
            if (connectionState != ConnectionState.Open)
                conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT NEXT VALUE FOR MySequence;";
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
        }
        catch (Exception ex)
        {
            throw new HCSSException(ex.Message, ex);
        }
        finally
        {
            if (connectionState != ConnectionState.Open)
                conn.Close();
        }
        return Convert.ToInt64(dt.AsEnumerable().First().ItemArray[0]);
    }
    public void Save()
    {
        using (var tx = new TransactionScope())
        {
            using (var context = new DbContext(connectionString))
            {
                var parent = new MyTable() { BaselineId = NextBaseline(context), Latest = true };
                var child = new MyTable() { BaselineId = NextBaseline(context), ParentBaselineId = parent.BaselineId, Latest = true }
                context.MyTable.Add(parent);
                context.MyTable.Add(child);
                context.SaveChanges();
            }
    
            tx.Complete();
        }
    }
