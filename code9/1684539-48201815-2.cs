    DataTable CreateIntList(IEnumerable<int> values)
    {
        var dt = new DataTable();
        // Note: Columns order matters! 
        // if you have a udt with multiple columns, 
        // your data table must reflect the columns exactly in the same order.
        dt.Columns.Add("val", typeof(int));
        foreach(var val in values)
        {
            dt.Rows.Add(val);
        }
    }
    void GetValuesBySkuOrStore(Ienumerable<int> skus, Ienumerable<int> stores)
    {
        var skusDT = CreateIntList(skus);
        var storesDT = CreateIntList(stores); 
        using(var con = new SqlConnection(connectionString))
        {
            using(var cmd = new SqlCommand("GetValuesBySkuOrStore", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@skus", SqlDbType.Structured).Value = skus;
                cmd.Parameters.Add("@stores", SqlDbType.Structured).Value = stores;
                con.Open();
                using(var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        // do your stuff here...
                    }
                }
            }
        }
    }
