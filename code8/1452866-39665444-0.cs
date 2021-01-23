    public FileStreamResult GetFile(string filename)
    {
        try
        {
            if (!string.IsNullOrEmpty(filename))
            {
                //string filePath = HttpContext.Current.Server.MapPath("~/App_Data/") + fileName;
                DirectoryInfo dirInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/Documentos"));
                string filePath = dirInfo.FullName + @"\" + filename;
    
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return File(fs, "application/pdf");
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
        catch (Exception)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
