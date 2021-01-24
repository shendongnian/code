    [DirectMethod]
    public void downloadFile(string fname, string ftype)
    {
        HttpContext.Current.Response.ContentType = "APPLICATION/OCTET-STREAM";
        String Header = "Attachment; Filename=" + fname;
        HttpContext.Current.Response.AppendHeader("Content-Disposition", Header);
        System.IO.FileInfo Dfile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath("CopyFiles\\" + ftype + "\\"+ fname));
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.WriteFile(Dfile.FullName);
        HttpContext.Current.Response.End();
    }
