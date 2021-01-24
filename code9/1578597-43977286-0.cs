    DataTable dt = new DataTable(); // New DataTable
    dt.Columns.Add("Value", typeof(string)); // New column "Value"
    DataRow dr = null; // New DataRow to use inside foreach loop
    foreach (GridViewRow row in gv_TotalAllReg.Rows)
    {
        if (row.RowType == DataControlRowType.DataRow)
        {
            bool isChecked = ((CheckBox)row.FindControl("chk_box")).Checked;
            if (isChecked == true)
            {
                    //var ds = new DataSet();
                    //var dt = new DataTable("RegistrationDetails");
                    
                    // inserting data row- column name = "Value", value = "your_Value"
                    dr = dt.NewRow();
                    dr.SetField("Value", "your_Value");
                    dt.Rows.Add(dr);
                    int index = row.RowIndex;
                    bo.Para1 = "4";
                    bo.Para2 = "Innovation";
                    bo.Para3 = gv_TotalAllReg.DataKeys[index].Values[0].ToString();//Id
               }
            }
        }
