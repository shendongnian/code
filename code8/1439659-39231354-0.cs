    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            // Retrieve the underlying data item. In this example
            // the underlying data item is a DataRowView object. 
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            // Retrieve the state value for the current row. 
            String flag = rowView["active"].ToString();
            Button btn_Out = e.Row.FindControl("btn_Out") as Button;
            Button btn_In = e.Row.FindControl("btn_In") as Button;
            if (flag == "1") {
                btn_In.Visible = false;
                btn_Out.Visible = true;
            } else {
                btn_In.Visible = false;
                btn_Out.Visible = true;
            }
        }
    }
