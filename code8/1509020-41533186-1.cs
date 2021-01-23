    void AddSpeler(string name, string club)
    {
        conn.Open();
        Speler speler = new Speler();
        speler.Name = name;
        speler.Club = club;
        string query = @"INSERT INTO Speler (Name, Club) OUTPUT Inserted.ID 
                         VALUES (@name, @club)";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = speler.Name;
        cmd.Parameters.Add("@club", SqlDbType.NVarChar).Value = speler.Club;
        speler.ID = (int)cmd.ExecuteScalar();
        conn.Close();
    }
