    public partial class _Default : Page
    {
        public List<links> googleRec = new List<links>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                googleRec = GetLinks();
                Session["links"] = googleRec;
            }
            else
            {
                googleRec = (List<links>)Session["links"];
            }
        }
        private List<links> GetLinks()
        {
            return new List<links>
            {
                new links {description = "new link 1", place = 1, title = "link title 1", url = "https://www.facebook.com/" },
                new links {description = "new link 2", place = 2, title = "link title 2", url = "http://www.google.pl" },
                new links {description = "new link 3", place = 3, title = "link title 3", url = "https://twitter.com/?lang=pl" },
            };
        }
    }
