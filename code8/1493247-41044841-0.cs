    protected void Application_BeginRequest()
            {
                if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
                {
                    Response.Headers.Add("Access-Control-Allow-Origin", "http://IP:PORT");
                    Response.Headers.Add("Access-Control-Allow-Headers", "Origin, Content-Type, X-Auth-Token");
                    Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PATCH, PUT, DELETE, OPTIONS");
                    Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                    Response.Headers.Add("Access-Control-Max-Age", "1728000");
                    Response.End();
                }
            }
