     HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
                if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
                {
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET");// or POST, PUT and etc.. 
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                    HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                    HttpContext.Current.Response.End();
                }
