    public BaseController()
            {
                try
                {
                    int UserID = 0;
                    if (System.Web.HttpContext.Current.Session["UserId"] != null)
                        UserID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserId"]);
    
                    if (!(UserID > 0))
                    {
                        System.Web.HttpContext.Current.Response.Redirect("controller/view");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
