    protected void SetResponseToText(string fileName)
    {
        HttpContext.Response.Clear();
        HttpContext.Response.AddHeader("content-disposition",
           "attachment;filename=" + fileName);
        HttpContext.Response.Charset = "";
        HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Response.ContentType = "text/csv";
    }
