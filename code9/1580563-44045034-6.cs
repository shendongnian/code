    var tmpPath = Path.GetTempFileName();
    try
    {
        File.WriteAllBytes(tmpPath, Resources.sendToPPTTemp);
        
        var myppnt = ppntApplication.Presentations.Open(tmpPath);
        ppntApplication.Visible = MsoTriState.msoTrue;
        [..]
    }
    finally
    {
        // you have to delete your tmp file at the end!!!
        // probably not the better way to do it because I guess the program does not block on Open.
        // Better store the file path into a list and delete later.
        var fi = new FileInfo(tmpPath);
        fi.Delete();
    }
