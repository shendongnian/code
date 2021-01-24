        public partial class NoServerControls : System.Web.UI.Page
        {
            public string echo { get; set; }
            protected void Page_Load(object sender, EventArgs e)
            {
                //Trivial example: skipping all validation checks
                //It's either a GET or POST end of day
                if (Request.RequestType == "POST")
                {
                    //Do something with data, just echoing it here
                    echo = Request["wtf"];
                }
                
            }
        }
