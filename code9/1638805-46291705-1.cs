    public String DisplaySheetList()
    {
        DataTable dt = new DataTable();
        GridView gv = new GridView();
    
        string sqlStatement1 = "SELECT cs.SheetId AS sheet_id, ltm.LocationType AS location_type, cs.PalletNo AS palletNo, cs.period AS period,cs.syncDate AS syncDate,cs.syncStatus AS syncStatus "
                    + "FROM CountSheet cs JOIN LocationTypeMaster ltm ON ltm.LocationId = cs.LocationId " +
                    " ORDER BY 1 DESC";
        SqlCommand sqlCmd1 = new SqlCommand(sqlStatement1, conn); 
    	SqlDataAdapter sqlDa1 = new SqlDataAdapter(sqlCmd1);
        sqlDa1.Fill(dt);
    	
    	//put it in the gridview datasource.	
    	gv.DataSource = dt;
    	
    	gv.DataBind();
    }
