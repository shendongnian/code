    getData[] allData = null;
    string sql = @"SELECT col1, col2 FROM Carrier";
    using (var command = new SqlCommand(sql, con))
    {
    con.Open();
    using (var reader = command.ExecuteReader()){
        var list = new List<getData>();
        while (reader.Read())
            list.Add(new getData{ Col1 = reader.GetString(0), Col2 = 
            reader.GetString(1) });
        allData = list.ToArray();
    }
