    SqlDataReader reader = cmddel.ExecuteReader();
    while (reader.Read())
    {
        string FilePath = reader[0] as string;
        string path = Server.MapPath(FilePath);
        FileInfo file = new FileInfo(path);
        if (file.Exists)
        {
            file.Delete();
        }
    }
    reader.Close();   // <- close the reader
