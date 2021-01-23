    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //find the dropdownlist in the row with findcontrol and cast it back to one
            DropDownList ddlprice = e.Row.FindControl("ddlprice") as DropDownList;
    
            //you now have access to all the dropdownlist properties
            ddlprice.DataSource = Course.getListCoursePriceOrdered();
            ddlprice.DataValueField = "id";
            ddlprice.DataTextField = "price";
            ddlprice.DataBind();
            ddlprice.SelectedValue = "0";
        }
    }
