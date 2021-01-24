    Session["UserID"] = "test1 value";
    Session["UserName"] = "test2 value";
    Session["Photo"] = "test3 value";
     
    foreach (string key in Session.Keys)
    {
         Session.Remove(key);
    }
    
    Response.Write(Session["UserID"]);
    Response.Write(Session["UserName"]);
    Response.Write(Session["Photo"]);
