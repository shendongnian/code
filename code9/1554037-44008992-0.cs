    [HttpGet]
    [Route("~/download/{filename}")]
    public void Download(string filename)
    {
        // TODO lookup file path by {filename}
        // If you want to have "." in {filename} you need enable in webconfig
        string filePath = "<path>"; // your file path here
        byte[] fileBytes = File.ReadAllBytes(filePath);
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Accept-Ranges", "bytes");
        HttpContext.Current.Response.ContentType = "application/octet-stream";
        HttpContext.Current.Response.AddHeader("ContentDisposition", "attachment, filename=" + filename);
        HttpContext.Current.Response.BinaryWrite(fileBytes);
        HttpContext.Current.Response.End();
    }
