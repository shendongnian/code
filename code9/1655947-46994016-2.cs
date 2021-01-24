    var p = Path.Combine(Path.IsPathRooted(Settings.ImagesPath)
                                ? path : Server.MapPath(Settings.ImagesPath), name);
    if (System.IO.File.Exists(p))
    {
        System.IO.File.Delete(p);
    }
