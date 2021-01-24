    private void DownloadFile(string file)
    {
        var fi = new FileInfo(file);
        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename="+ fi.Name);
        Response.WriteFile(file);
        Response.End();
    }
