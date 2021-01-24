    // Add parameters to SqlCommand
    command.Parameters.Add(emailparam);
    command.Parameters.Add(baseparam);
    command.Parameters.Add(tccparam);
 
    // *NOW* you can open connection, execute query, close connection
    con.Open();
    command.ExecuteNonQuery();
    con.Close();
