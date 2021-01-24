    protected void Page_Load(object sender, EventArgs e)
    {
    if (IsPostBack)  
        {
             //capture SORT request (which View?)
             string RequestType = (get the grid request type);  
             if(RequestType  = "SortView1")
             {
                 GridView1.datasourceID = datasource1; 
                 GridView1.DataBind();
             }
             else if(RequestType  = "SortView2")
             {
                 GridView1.datasourceID = datasource2; 
                 GridView1.DataBind();
             }
 
        }
    }
