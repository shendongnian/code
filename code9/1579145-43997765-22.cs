    MySqlCommand command = new MySqlCommand("", connection);
    command.CommandText = "SELECT VideoName, VideoSize, VideoFile FROM video WHERE VideoName=?videoname;";
    MySqlParameter pVideoname = new MySqlParameter("?videoname", MySqlDbType.VarChar);
    pVideoname.Value = Path.GetFileName(videoName);
    command.Parameters.Add(pVideoname);
    MySqlDataReader videofileReader;
    videofileReader = command.ExecuteReader();
    byte[] videoBlob = new byte[0];
    while (videofileReader.Read())
    {
        int videoSize = videofileReader.GetInt32("VideoSize");
        videoBlob = new byte[videoSize];
        videofileReader.GetBytes(videofileReader.GetOrdinal("VideoFile"), 0, videoBlob, 0, videoSize);
    }
    File.WriteAllBytes(@"C:\Encoding\export.wmv", videoBlob);
    videofileReader.Close();
    CloseConnection();
