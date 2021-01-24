     DataTable dt= new DataTable();
    //Columns that should present in datatable
    dt.Columns.Add("SN");
    dt.Columns.Add("MyField");
    int sn = 1;
    foreach (GridViewRow row in gv_TotalAllReg.Rows)
    {
    	if (row.RowType == DataControlRowType.DataRow)
    	{
    		bool isChecked = ((CheckBox)row.FindControl("chk_box")).Checked;
    		if (isChecked == true)
    		{
    			DataRow row = dt.NewRow();
    			//Add necessary columns to row by index.
    			row[0] = sn;
    			row[1] = gv_TotalAllReg.DataKeys[index].Values[0].ToString();   
    			dt.Rows.Add(row); 
    			sn++;
    		}
    	}
    }
    if (tbl .Rows.Count > 0)
    {
    ds.Tables.Add(dt);
    ExcelHelper.ToExcel(ds, "ApplicationDetails.xls", Page.Response);
    btnExport.Visible = true;
    }
