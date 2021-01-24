    public partial class MyPage: System.Web.UI.Page
    {
        protected int Counter { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // MyLabel (<asp: Label>) will perform a post-back every 1000 milliseconds
                int _newCounter;
                var newCount = Request.Form["__EVENTARGUMENT"];
                if (newCount != null)
                {
                    if (int.TryParse(newCount, out _newCounter))
                    {
                        Counter = _newCounter;
                        Counter++;
                    }
                }
            }
            // Loading javascript that will trigger the postback
            
            var _pageType = this.GetType();
            var script =
                string.Concat(
                    "setTimeout(function() { ",
                    ClientScript.GetPostBackEventReference(MyLabel, Counter.ToString(), false),
                    "; }, 1000);");
            ClientScript.RegisterStartupScript(_pageType, "AutoPostBackScript", script, true);
        }
    }
