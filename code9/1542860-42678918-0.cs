    foreach(var prod in ProductsList.GroupBy(p => p.ProdID).Select(p => p.Count() > 1))
    {
        using (MySqlConnection conn = new MySqlConnection(connStr))
        using (MySqlCommand comm = new MySqlCommand(sqlString, conn))
        {
            comm.Parameters.Add("@ProdID", MySqlDbType.VarChar).Value = prod.ProdID;
            comm.Parameters.Add("@Name", MySqlDbType.VarChar).Value = prod.Name;
            comm.Parameters.Add("@Color", MySqlDbType.VarChar).Value = prod.Color;
            comm.Parameters.Add("@Availability", MySqlDbType.VarChar).Value = prod.Availability;
            comm.Parameters.Add("@Duplicate", MySqlDbType.VarChar).Value = "Yes";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
