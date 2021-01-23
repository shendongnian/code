    var connectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
    var sql = "SELECT ItemOne, ItemTwo, ItemThree FROM tableItem";
    using (var table = new DataTable) {
        using (var adapter = new SqlDataAdapter(sql, connectionString)
            adapter.Fill(table);
        foreach (DataRow dr in table.Rows)
            DropDownList1.Items.Add(new ListItem(dr["ItemTwo"], dr["ItemTwo"]) {
                Tag = dr["ItemThree"]
            });
    }
