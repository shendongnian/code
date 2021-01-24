    MySqlCommand command = new MySqlCommand("", connection);
    command.CommandText = "INSERT INTO video (VideoName, VideoSize, VideoFile) VALUES (?videoname, ?videosize, ?videofile);";
    
    byte[] video = File.ReadAllBytes(filepath);
    
    MySqlParameter pVideoName= new MySqlParameter("?videoname", MySqlDbType.VarChar);
    pVideoName.Value = Path.GetFileName(filepath);
    MySqlParameter pVideoSize = new MySqlParameter("?videosize", MySqlDbType.Int32);
    pVideoSize.Value = video.Length;
    MySqlParameter pVideoBlob= new MySqlParameter("?videofile", MySqlDbType.Blob, video.Length);
    pVideoBlob.Value = video;
    
    command.Parameters.Add(pVideoName);
    command.Parameters.Add(pVideoSize);
    command.Parameters.Add(pVideoBlob);
    command.ExecuteNonQuery();  
