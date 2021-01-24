    using(MySqlConnection connection = new MySqlConnection(MyConnectionString))
    using(MySqlCommand cmd = connection.CreateCommand())
    {
        connection.Open();
        cmd.CommandText = 
    @"select * from TableA;
    
    select * from TableB;
    
    SELECT a.Id, a.Foo, b.Bar FROM tableA a, tableB b where a.Id = b.Id;";
    
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
    }
