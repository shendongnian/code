        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               Session["savedViewState"] = SaveViewState();
            }
            else
            {
                
                  if(Session["savedViewState"] != null)
                  {
                     Object saved = (Object)Session["savedViewState"];
                     LoadViewState(saved);
                  }   
            }
        }
