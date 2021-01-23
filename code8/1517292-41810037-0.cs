    using(var con = new Connection())
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con.InfoTableConnection;
        cmd.CommandText = "SELECT * FROM [dbo].[Item] ORDER by [Type] ASC";
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            cmbType.Items.Add(reader["Type"].ToString());
        }
    }
