        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["id"] != null)
            {
                string idnr = context.Request.QueryString["id"].ToString();
                if (idnr.Length > 0 && idnr.Length < 40)
                {
                    byte[] bin = //get the data from the db;
                    context.Response.ClearHeaders();
                    context.Response.ClearContent();
                    context.Response.Clear();
                    context.Response.Buffer = true;
                    context.Response.ContentType = "image/jpeg";
                    context.Response.AddHeader("Content-Disposition", "attachment; filename=\"myImage.jpg\"");
                    context.Response.Cache.SetExpires(DateTime.Now.AddMonths(1));
                    context.Response.Cache.SetCacheability(HttpCacheability.Public);
                    context.Response.Cache.SetValidUntilExpires(false);
                    context.Response.AddHeader("content-Length", bin.Length.ToString());
                    context.Response.OutputStream.Write(bin, 0, bin.Length);
                    context.Response.Flush();
                    context.Response.Close();
                    context.Response.End();
                }
                else
                {
                    context.Response.Write("");
                }
            }
        }
