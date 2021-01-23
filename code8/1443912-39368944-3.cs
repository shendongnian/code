        public void ProcessRequest(HttpContext context)
        {
            //check if the querystring 'id' exists
            if (context.Request.QueryString["id"] != null)
            {
                string idnr = context.Request.QueryString["id"].ToString();
                //check if the id falls withing length parameters
                if (idnr.Length > 0 && idnr.Length < 40)
                {
                    byte[] bin;
                    //clear the headers
                    context.Response.ClearHeaders();
                    context.Response.ClearContent();
                    context.Response.Clear();
                    context.Response.Buffer = true;
                    //if you do not want the images to be cached by the browser remove these 3 lines
                    context.Response.Cache.SetExpires(DateTime.Now.AddMonths(1));
                    context.Response.Cache.SetCacheability(HttpCacheability.Public);
                    context.Response.Cache.SetValidUntilExpires(false);
                    //set the content type and headers
                    context.Response.ContentType = "image/jpeg";
                    context.Response.AddHeader("Content-Disposition", "attachment; filename=\"myImage.jpg\"");
                    context.Response.AddHeader("content-Length", bin.Length.ToString());
                    //write the byte array
                    context.Response.OutputStream.Write(bin, 0, bin.Length);
                    //cleanup
                    context.Response.Flush();
                    context.Response.Close();
                    context.Response.End();
                }
            }
        }
