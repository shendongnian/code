    string SQL = "SELECT itemName, itemData, itemtype FROM BlobDemo WHERE Id = @id";
    
    string ext = "";
    string tempFile = Path.Combine(@"C:\Temp\Blobs\", 
        Path.GetFileNameWithoutExtension(Path.GetTempFileName())); 
    
    using (MySqlConnection dbCon = new MySqlConnection(MySQLConnStr))
    using (MySqlCommand cmd = new MySqlCommand(SQL, dbCon))
    {
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = 14;
        dbCon.Open();
    
        using (MySqlDataReader rdr =  cmd.ExecuteReader())
        {
            if (rdr.Read())
            {
                ext = rdr.GetString(2);
                File.WriteAllBytes(tempFile + ext, (byte[])rdr["itemData"]);
            }
        }
       
        // OS run test
        Process prc = new Process();
        prc.StartInfo.FileName = tempFile + ext;
        prc.Start();
    }
