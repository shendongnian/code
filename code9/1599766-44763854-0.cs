    public string getHtml()
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.fa-mag.com/search.php?and_or=and&date_range=all&magazine=&sort=newest&method=basic&query=ubs");
        req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:54.0) Gecko/20100101 Firefox/54.0";
        req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        req.AllowAutoRedirect = false;
        req.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.5");
        req.Headers.Add("cookie", "analytics_id=595127c20cdfe6.52043028595127c20ce022.71834842; PHPSESSID=tbbo7npldsv26n2q7pg2728k77; D_IID=3E4FEA7F-9794-34EE-99F8-87EEA3DF0689; D_UID=5F374D94-270D-3653-8C54-9A46F381EAE2; D_ZID=505BB8EF-5A2D-3CBD-87D8-FABAD5014776; D_ZUID=BB0C9EF2-0E7B-383E-A03A-A3E92CC8051A; D_HID=9642D775-D860-3F04-8720-73E5339042BA; D_SID=63.138.127.22:6Ci6jv2Xv+yum3m9lNfnyRcAylne67YfnS/u8goKrxQ");
        req.Headers.Add("DNT", "1");
        req.Headers.Add("Upgrade-Insecure-Requests", "1");
        HttpWebResponse res = null;
        try
        {
            res = (HttpWebResponse)req.GetResponse();
        }
        catch (WebException webex)
        {
            res = (HttpWebResponse)webex.Response;
        }
        string html = new StreamReader(res.GetResponseStream()).ReadToEnd();
        return html;
    }
