    public static string GetUserEmail(this HttpSessionState session)
    {
        if(Session["Email"] != null)
          {
              Session["email"] = ..Set Session email here
          }
        
        return session["Email"]
    }
