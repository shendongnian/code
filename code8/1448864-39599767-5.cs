    string SQL = "SELECT imgData FROM BlobDemo WHERE Id = @id";
    
    byte[] imgBytes = null;
    
    using (MySqlConnection dbCon = new MySqlConnection(MySQLConnStr))
    using (MySqlCommand cmd = new MySqlCommand(SQL, dbCon))
    {
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value =8;
        dbCon.Open();
    
        using (MySqlDataReader rdr = cmd.ExecuteReader())
        {
            if (rdr.Read())
                imgBytes = (byte[])rdr[0];
        }
        
        // todo: check imgbytes ! null
    
        // restore as file
        string imgFileName = @"C:\Temp\ImgFromBlob.jpg";
        File.WriteAllBytes(imgFileName, imgBytes);
        
        // recreate Image, show on form
        using (var ms = new MemoryStream(imgBytes))
        {
            Image img = Image.FromStream(ms);
            picBox.Image = img;
        }
    
        // OS run test
        Process prc = new Process();
        prc.StartInfo.FileName = imgFileName;
        prc.Start();
    }
