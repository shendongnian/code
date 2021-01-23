    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "getValuesFromGrid")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
    
            TextBox textBox = GridView1.Rows[rowNumber].FindControl("TextBox1") as TextBox;
            DropDownList dropDownList = GridView1.Rows[rowNumber].FindControl("DropDownList1") as DropDownList;
            Label label = GridView1.Rows[rowNumber].FindControl("Label1") as Label;
        }
    }
