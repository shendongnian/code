    public static aspnet_Users LogInUser
            {
                get
                {
                    if (HttpContext.Current.Session["LogInUser"] != null)
                    {
                        return (aspnet_Users)HttpContext.Current.Session["LogInUser"];
                    }
                    else
                    {
                        return null;
                    }
                }
                set
                {
                    HttpContext.Current.Session["LogInUser"] = value;
                }
            }
