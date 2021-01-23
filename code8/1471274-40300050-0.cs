    string commandText = "select BookName, Publisher, Category, Edition, Year,"
                         + "Location from library.add_update "
                         + "where BookName like @name and Publisher=@publisher'"
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        command.Parameters.Add("@name", SqlDbType.Varchar);
        command.Parameters.Add("@publisher", SqlDbType.Varchar);
        command.Parameters["@name"].Value = "%book name%";
        command.Parameters["@publisher"].Value = "publisher name";
        connection.Open();
        Int32 num_rows = command.ExecuteNonQuery();
    }
