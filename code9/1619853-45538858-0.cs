    private void dwnldFile(string filepath)
    {
    	FileInfo fInfo = new FileInfo(filepath);
    	Response.Clear();
    	Response.ContentType = "application/octet-stream";
    	Response.AddHeader("Content-Length", fInfo.Length.ToString);
    	Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", fInfo.Name));
    	Response.Flush();
        Response.TransmitFile(fInfo.FullName)
    	Response.End();
    }
