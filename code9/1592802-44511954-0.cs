    public partial class counter : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
            Response.ContentType = "text/javascript";
                UICulture = "en-US";
                Culture = "en-US";
                int siteid = int.Parse(Request.QueryString["siteid"].ToString());
                string referedby = Request.QueryString["referedby"];
                string pubIp = new System.Net.WebClient().DownloadString("https://api.ipify.org");
                var ipResponse = GetCountryByIP(pubIp);
                HttpBrowserCapabilities browse = Request.Browser;
                string platform = browse.Platform;
                string browsername = browse.Browser;
     Counter cnt = new Counter();
            var counter = cnt.GetCounter(siteid, DateTime.Now, pubIp, referedby, platform, browsername, "", ipResponse.Country);
                    string text = "document.write('<div id=\"ShortCounter\" style=\" margin: 0px auto;width: 100px;min-height: 100px;font-family: Tahoma;font-size: x-small;background-color:" + counter.BackColor + ";color:" + counter.color + ";border:" + counter.BorderSize + "px " + counter.BorderStyle + " " + counter.BorderColor + ";\">" +
            "<div style=\"padding: 8px;\">" +
                "You Are Visitor Number:<br />" +
                counter.CounterNumber.ToString("N0") +
                "<br />" +
                "Today" +
            "<br />" +
                counter.Today.ToString("N0") +
                "<br />" +
                "This Week" +
            "<br />" +
                counter.ThisWeek.ToString("N0") +
                "<br />" +
                "This Month" +
            "<br />" +
                counter.ThisMounth.ToString("N0") +
                "<br />" +
            "</div>" +
            "<div style=\"width: 100%; background-color: darkred; text-align: center; padding-top: 2px; padding-bottom: 2px;\">" +
                Request.UrlReferrer.ToString() +
            "</div>');";
    
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);
    
                    Response.OutputStream.Write(bytes, 0, bytes.Length);
    }
