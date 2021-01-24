    var tmpPath = Path.GetTempFileName();
    try
    {
        File.WriteAllBytes(tmpPath, Resources.sendToPPTTemp);
        
        var myppnt = ppntApplication.Presentations.Open(tmpPath);
        ppntApplication.Visible = MsoTriState.msoTrue;
    }
    finally
    {
        var fi = new FileInfo(tmpPath);
        fi.Delete(); // you have to delete your tmp file at the end!!!
    }
