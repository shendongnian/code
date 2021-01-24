    //SELECT col1, col2, ..., coln FROM tbl; 
    SqlDataReader reader = command.ExecuteReader();
    if (reader.HasRows)
    {
        while (reader.Read())
        {
                Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                    reader.GetString(1));
        }
    }
    else
    {
       Console.WriteLine("No rows found.");
    }
    reader.Close();
