    DataTable dt = bl.Admin_GetInnovationbaseonParaType(bo);
    if (gv_TotalAllReg.Rows.Count > 0)
    {
         dt.TableName = "RegistrationDetails";
         ds.Tables.Add(dt);               
         foreach (GridViewRow row in gv_TotalAllReg.Rows)
         {
             if (row.RowType == DataControlRowType.DataRow)
             {
                 bool isChecked = ((CheckBox)row.FindControl("chk_box")).Checked;
                 if (isChecked == true)
                 {                    
                    // inserting data row
                    dr = dt.NewRow();
                    dr.SetField("Column_Name", "your_Value");
                    dt.Rows.Add(dr);
                    int index = row.RowIndex;
                    bo.Para1 = "4";
                    bo.Para2 = "Innovation";
                    bo.Para3 = gv_TotalAllReg.DataKeys[index].Values[0].ToString();//Id
                 }
             }
        }
        ExcelHelper.ToExcel(ds, "ApplicationDetails.xls", Page.Response);
        btnExport.Visible = true;
    }
