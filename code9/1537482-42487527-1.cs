    string queryText = "INSERT INTO firmenkunden (";
    for (int i = 0; i < textboxes.Count; i++)
    {
        var column = labels[i];
        if (i < textboxes.Count - 1)
            queryText += column.Name + ",";
        else
            queryText += column.Name;
    }
    queryText += ") VALUES (";
    for (int i = 0; i < textboxes.Count; i++)
    {
        var value = textboxes[i];
        if (i < textboxes.Count - 1)
            queryText += "'" + value.Text + "',";
        else
            queryText += "'" + value.Text + "')";
    }
    MySqlCommand cmd = connection.CreateCommand();
    cmd.CommandText = queryText;
    cmd.ExecuteNonQuery();
