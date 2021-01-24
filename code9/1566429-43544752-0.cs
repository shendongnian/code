    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
       {
         string SearchTerm = Request.QueryString["searchTerm"];
         //Do database search and bind to a gridview
       }
    }
