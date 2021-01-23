    void InsertRowIntoTempTable(int id, int fingers, int thumbs)
    {
        using (var conn = this.GetDatabaseConnection())
        {
            var cmd = new SqlCommand(conn);
            cmd.CommandText = String.Format("INSERT INTO TempTable VALUES ({0},{1},{2})", id, fingers, thumbs);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
    void InsertRowsIntoTempTable(DataTable source)
    {
        for each (var row in source.Rows)
        {
            InsertRowIntoTempTable(row["ID"], row["Fingers"], row["Thumbs"]);
        }
    }
