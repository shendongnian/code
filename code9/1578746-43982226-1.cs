    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    foreach (GridViewRow row1 in gv_TotalAllReg.Rows)
    {
        if (row1.RowType == DataControlRowType.DataRow)
        {
            bool isChecked = ((CheckBox)row1.FindControl("chk_box")).Checked;
            if (isChecked == true)
            {
                int index = row1.RowIndex;
                bo.Para1 = "4";
                bo.Para2 = "Innovation";
                bo.Para3 = gv_TotalAllReg.DataKeys[index].Values[0].ToString();//Id
                var tempdt = bl.Admin_GetInnovationbaseonParaType(bo);
                foreach(var temprow in tempdt.Rows) 
                {
                    dt.Rows.Add(temprow);
                }
            }
        }    
    }
    ds.Tables.Add(dt);    
    if (gv_TotalAllReg.Rows.Count > 0)
    {
        ExcelHelper.ToExcel(ds, "ApplicationDetails.xls", Page.Response);
        btnExport.Visible = true;
    }
