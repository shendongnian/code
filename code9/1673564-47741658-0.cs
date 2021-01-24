    // GET: Members/SendBatch
    public ActionResult SendBatch()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SendBatch(Membership member)
    {
        var db = new ChurchContext();
        StreamReader objReader;
        WebClient client = new WebClient();
        string mess = member.Message;
        string cell = member.Cell;
        string pass = "xxxx";
        string user = "xxxx";
        string selectministries = member.SelectMinistries;
        string pathtoministries = "";
        pathtoministries = GetMinisry(selectministries);
        if (pathtoministries == "Youth")
        {
            var youthtable = from e in db.Youths
                             select e;
            var Entyouth = youthtable.ToList();
            foreach (Youth y in Entyouth)
            {
                string youthcell = y.ContactMobile.ToString();
                cell = youthcell;
      string baseurl = "http://bulksms.2way.co.za/eapi/submission/send_sms/2/2.0?" +
     "username=" + user + "&" +
     "password=" + pass + "&" +
     "message=" + mess + "&" +
     "msisdn=" + cell;
        WebRequest wrGETURL;
        wrGETURL = WebRequest.Create(baseurl);
        try
        {
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            objReader = new StreamReader(objStream);
            objReader.Close();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        return View("Index", member);
            }
        }
    }
    public static string GetMinisry(string ministry)
    {
        string membership = "";
        switch (ministry)
        {
            case "Youth":
                membership = "Youth";
                break;
            case "Children":
                membership = "Children";
                break;
            case "Men":
                membership = "Men";
                break;
            case "Women":
                membership = "Women";
                break;
            case "Visitors":
                membership = "Visitors";
                break;
            case "Members":
                membership = "Members";
                break;
        }
        return membership;
    }
