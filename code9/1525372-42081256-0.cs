    int roboIdFromSql;
    // Because you know that id is int so imho you don't need parameters.
    queryStr = "SELECT ipaddress from robolinks where roboID="+roboID+";";
    // This is right.
    cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
    var dr = cmd.ExecuteReader();
    // Now check if any rows returned.
    if (dr.HasRows)
    {
        dr.Read();// Get first record.
        roboIdFromSql = dr.GetInt32(0);// Get value of first column as int.
    }
    dr.Close();// Close reader.
    conn.Close();// Close connection.
