    SqlCommand command = new SqlCommand();
    command.CommandType = CommandType.Text;
    command.Connection = connection;
    command.Parameters.Clear();
    var sql = "INSERT INTO POStable2(";
    var values = "Values(";
    for (int k = 0; k < listBox1.Items.Count; k++)
    {
        sql = sql + "L" + k + ",";
        values = values + "@L" + k + ",";
        command.Parameters.AddWithValue("@L" + k +"", listBox1.Items[k].ToString());
        
    }
    sql = sql.TrimEnd(",") + ") " + values.TrimEnd(",") + ") ";
    command.CommandText = sql;
    connection.Open();
    command.ExecuteNonQuery();
    connection.Close();
