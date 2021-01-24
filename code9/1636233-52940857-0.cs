    public void ProcessRequest(HttpContext context)
    {
        using (var md5 = MD5.Create())
        {
            foreach (var file in context.Request.Files)
            {
                var hash = md5.ComputeHash(file.InputStream);
                // do whatever with the file + md5 now
            }
        }
    }
