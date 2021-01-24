    Response.ContentType = "application/zip";
    Response.AppendHeader("content-disposition", "attachment; filename=\"Download.zip\"");
    using (ZipOutputStream zOut = new ZipOutputStream(HttpContext.Current.Response.OutputStream))
    {
        FileInfo f1 = new FileInfo(fileName1);
        zOut.PutNextEntry(f1.Name);
        using (var input = f1.OpenRead())
        {
            byte[] buffer = new byte[2048];
            int n;
            while ((n = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                zOut.Write(buffer, 0, n);
            }
        }
    }
