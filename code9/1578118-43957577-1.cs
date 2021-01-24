    Page_Load(..) {
    	if (!IsPostBack) {
    		var dt = GetCountries();
    		BindGrid(GridView1, dt);
    	}
    }
    
    BindGrid(GridView grid, DataTable dt) {
    	grid.DataSource = dt;
    	grid.DataBind();
    }
    
    GetCountries() {
    	// your get_table() code here
    	return dt;
    }
    
    GridView1_PageIndexChanging(..) {
    	GridView1.PageIndex = e.NewPageIndex;
        var dt = GetCountries();
    	BindGrid(GridView1, dt);
    }
