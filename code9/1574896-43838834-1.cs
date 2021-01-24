    // These come from whatever your source which you have no control over.
    int id = 12345;
    string name = "Andrew";
    string otherName = "Fred";
    var sql = "Insert Into mytable (Id, Name, otherName) Values (@id, @name, @otherName)
    using (var sqlQuery = new SqlCommand(sql, sqlConnection)) 
    {
        sqlQuery.Parameters.AddWithValue("@id", id);
        sqlQuery.Parameters.AddWithValue("@name", name);
        sqlQuery.Parameters.AddWithValue("@otherName", otherName);
        sqlQuery.ExecuteNonQuery();
    }
