    string path = Server.MapPath("/Content/Images/" + id)
    if (!Directory.Exists(path))
    {
       // Try to create the directory.
       DirectoryInfo di = Directory.CreateDirectory(path);
    }
