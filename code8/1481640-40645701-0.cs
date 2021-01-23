    public static Runspace runspace
    {
      get
      {
        //if not exist, create, open and store
        if (Session["runspace"] == null){
            Runspace rs = RunspaceFactory.CreateRunspace();
            rs.Open();
            Session["runspace"] = rs;
        }
        //return from session
        return (Runspace)Session["runspace"];
      }
    }
