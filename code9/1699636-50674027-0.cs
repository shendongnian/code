    protected void Application_BeginRequest(Object sender, EventArgs e)
            {
               
                if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
                {
                    HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authorization ");
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
                    HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                    HttpContext.Current.Response.End();
                }
            }
