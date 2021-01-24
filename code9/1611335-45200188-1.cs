    //Retrieve the table from the session object.
    DataTable dt = (DataTable)Session["datasource"];
    //Update the values.           
    GridViewRow row = GridView2.Rows[e.RowIndex];
    TextBox txtRate = (TextBox)row.Cells[4].Controls[0];
    DataRow dataRow = dt.Rows[row.DataItemIndex];
    
    dataRow["Rate"] = Int32.Parse(txtRate.Text);
    GridView2.EditIndex = -1;
    //Bind data to the GridView control.
    BindData();
    Session["datasource"] = dt;
