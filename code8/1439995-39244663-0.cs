    protected void SetResponseToExcel(string fileName)
    {
        HttpContext.Response.Clear();
        HttpContext.Response.AddHeader("content-disposition",
          "attachment;filename=" + fileName);
        HttpContext.Response.Charset = "";
        HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Response.ContentType = "application/vnd.ms-excel";
    }
