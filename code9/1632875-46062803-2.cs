    dbc.Open();
    dbCmd = new OleDbCommand();
    var sB = new StringBuilder("UPDATE members SET ");
    for (int i = 0; i < updatedTextboxes.Count; i++)
    {
        if (i == 0)
        {
            sB.Append(updatedTextboxes[i].Key + " = ?");
        }
        else
        {
            sB.Append(", " + updatedTextboxes[i].Key + " = ?");
        }
        if (updatedTextboxes[i].Value == null)
        {
            dbCmd.Parameters.AddWithValue(updatedTextboxes[i].Key, DBNull.Value);
        }
        else
        {
            dbCmd.Parameters.AddWithValue(updatedTextboxes[i].Key, updatedTextboxes[i].Value);
        }
    }
    sB.Append(" WHERE ID = " + id);
    dbCmd.CommandText = sB.ToString();
    dbCmd.Connection = dbc;
    if (dbCmd.ExecuteNonQuery() > 0) .....
