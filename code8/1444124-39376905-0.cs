     public static  class CommonHelper
        {    
            public static SessionObjects sessionObjects
            {
                get
                {
                    if ((HttpContext.Current.Session["sessionObjects"] == null))
                        HttpContext.Current.Session.Add("sessionObjects", new SessionObjects()); 
                    return HttpContext.Current.Session["sessionObjects"] as SessionObjects;
                }
                set { HttpContext.Current.Session["sessionObjects"] = value; }
            }
        }
