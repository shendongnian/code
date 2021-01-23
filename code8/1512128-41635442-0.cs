     public List<string> updcomson(string Id, string upddate, string updcomname, string updbrandname, string updzone, string updlocation, string updstartime, string updendtime, string updprogram, string updvenue, string updvenuename, string pm, string pax)
        {
        //updating
        string errMessage  = SendEmailsms();
        con.Close();
        var json = js.Serialize(message);
        Context.Response.Write("{" + '"' + "message" + '"' + ":" + json + "}");
            List<string> plist = new List<string>();
            plist.Add(errMessage); 
            return plist;
        }
