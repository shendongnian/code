    if (HttpContext.Current.Request.Files.Count != 0)
    {
        if (HttpContext.Current.Request.Files[0].ContentLength > 0)
        {
            string ServerPath = Server.MapPath("/storage/");
            HttpContext.Current.Request.Files[0].SaveAs(ServerPath + HttpContext.Current.Request.Files[0].FileName);
            this.Context.Response.ContentType = "application/json; charset=utf-8";
            this.Context.Response.Write(HttpContext.Current.Request.Files[0].FileName);
            return;
        }
    }
