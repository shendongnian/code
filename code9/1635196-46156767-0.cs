    Session["test1"] = "test1 value";
    Session["test2"] = "test2 value";
    Session["test3"] = "test3 value";
     
    foreach (string key in Session.Keys)
    {
         Session.Remove(key);
    }
    
    Response.Write(Session["test1"]);
    Response.Write(Session["test2"]);
    Response.Write(Session["test3"]);
