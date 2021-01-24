    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.Files.Count > 0)
        {
            HttpFileCollection files = context.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                var hasAlg=HashAlgorithm.Create("MD5");
                var MD5= hasAlg.ComputeHash(file.InputStream);
            }
        }
    }
