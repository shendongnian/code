    //We changed this
    HttpContext.Current.Session["x"] = x;
    HttpContext.Current.Session["y"] = y;
    //To this
    HttpContext.Current.Session["guid"] = new SessionContent{x = x, y = y };
