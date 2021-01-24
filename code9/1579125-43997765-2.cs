    MySqlCommand command = new MySqlCommand("", connection);
    command.CommandText = "INSERT INTO video (VideoName, VideoFile) VALUES (?videoname, ?videofile);";
    
    byte[] video = File.ReadAllBytes(filepath);
    
    MySqlParameter pVideoname = new MySqlParameter("?videoname", MySqlDbType.VarChar);
    pVideoname.Value = Path.GetFileName(filepath);
    MySqlParameter pVideoblob = new MySqlParameter("?videofile", MySqlDbType.Blob, video.Length);
    pVideoblob.Value = video;
    
    command.Parameters.Add(pVideoname);
    command.Parameters.Add(pVideoblob);
    command.ExecuteNonQuery();  
