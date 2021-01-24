    public partial class MyPage: System.Web.UI.Page
    {
        protected int Counter { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // MyUpdatePanel will perform a async post-back every 1000 milliseconds
                int _newCounter;
                var newCount = Request.Form["__EVENTARGUMENT"];
                if (newCount != null)
                {
                    if (int.TryParse(newCount, out _newCounter))
                    {
                        Counter = _newCounter;
                    }
                }
                return;
            }
            // Loading javascript that will trigger the postback
            
            var _pageType = this.GetType();
            var script =
                string.Concat(
                    "var counter = 0;",
                    "setInterval(function() { ",
                    "__doPostBack('", MyUpdatePanel.UniqueID, "', counter);",
                    "counter++; }, 1000);");
            ClientScript.RegisterStartupScript(_pageType, "AutoPostBackScript", script, true);
        }
    }
