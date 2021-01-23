    Image img = ... from file or an image already in the app
    string sql = "INSERT INTO BlobDemo (imgData) VALUES (@img)";
    byte[] imgBytes;
    
    using (MySqlConnection dbCon = new MySqlConnection(MySQLConnStr))
    using (MySqlCommand cmd = new MySqlCommand(sql, dbCon))
    {
        // load bytes from  a disk file:
        //imgBytes = File.ReadAllBytes(...)
        // converting an img you have (this can be an extension)
        using (MemoryStream ms = new MemoryStream())
        {
            img.Save(ms, ImageFormat.Jpeg);
            imgBytes = ms.ToArray();
        }
        
        dbCon.Open();
        cmd.Parameters.Add("@img", MySqlDbType.Blob).Value = imgBytes;
        int rows = cmd.ExecuteNonQuery();
    }
