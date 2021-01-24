    protected void Application_EndRequest(object sender, EventArgs e)
            {
                
                    if (Response.Cookies.Count > 0)
                    {
                        foreach (string s in Response.Cookies.AllKeys)
                        {
                            Response.Cookies[s].Secure = true;
                        }
                    }
                }
            }
