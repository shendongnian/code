    private List<int> IDs
    {
    	get{ return (List<int>)ViewState["IDs"]; }
    	set{ ViewState["IDs"] = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
    	if (!IsPostBack)
    	{
    		IDs = GetIds();
            //IDs will be available in the next postbacks
    	}
    }
