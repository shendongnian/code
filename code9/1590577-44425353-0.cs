    string tempFolder = Server.MapPath("~/TEMP");
    if (!Directory.Exists(tempFolder))
    {
        Directory.CreateDirectory(tempFolder);
    }
