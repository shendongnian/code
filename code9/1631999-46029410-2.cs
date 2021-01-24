    public string constr = String.Empty;
    if(Request.Cookies["linkbutton"].ToString()=="Button was click")
    {
         constr = ConfigurationManager.ConnectionStrings["Second"].ToString()
    }
    else
    {
          constr = ConfigurationManager.ConnectionStrings["Default"].ToString()
    }
