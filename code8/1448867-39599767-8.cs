    string sql = "INSERT INTO BlobDemo (filename, fileType, fileData) VALUES (@name, @type, @data)";
    byte[] imgBytes;
    
    using (MySqlConnection dbCon = new MySqlConnection(MySQLConnStr))
    using (MySqlCommand cmd = new MySqlCommand(sql, dbCon))
    {  
        string ext = Path.GetExtension(filename);
        dbCon.Open();
        cmd.Parameters.Add("@name", MySqlDbType.String).Value = "ziggy";
        cmd.Parameters.Add("@data", MySqlDbType.Blob).Value = File.ReadAllBytes(filename);
        cmd.Parameters.Add("@tyoe", MySqlDbType.String).Value = ext;
        int rows = cmd.ExecuteNonQuery();
    }
