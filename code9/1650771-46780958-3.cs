    public List<string> GetButtonNames()
    {
        var buttonNames = new List<string>();
        SqlCommand sqlCmd = new SqlCommand("Select Name from TablesDesigner", con);
        using (var sqlReader = sqlCmd.ExecuteReader())
        {
            while (sqlReader.Read())
            {
                buttonNames.Add(sqlReader["Name"].ToString());
            }
        }
        return buttonNames;
    }
