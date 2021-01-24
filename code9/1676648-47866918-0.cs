    string assignedValue = string.Empty;
    assignedValue = string.IsNullOrEmpty(txtpictext.Text) ? DBNull.Value : txtpictext.Text ;
    Cmd.Parameters.AddWithValue("@pictext", assignedValue);
    Conn.Open();
    Cmd.ExecuteNonQuery();
