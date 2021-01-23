            [WebMethod]
            public static string AddNewLoc(string terminalid, string hospid, string userid)
            {
                //access session like this from backend or set sesssion value
                long TerminalID = Convert.ToInt64(HttpContext.Current.Session["TerminalID"]);
                //Do some stuf
    
                return "true";
            }
