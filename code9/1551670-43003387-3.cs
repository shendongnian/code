    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //the header row
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //normal row
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                //normal row in edit mode
                DropDownList ddl = e.Row.FindControl("DropDownListEditItem") as DropDownList;
                ddl.DataSource = distinctValues;
                ddl.DataTextField = "myValue";
                ddl.DataValueField = "ID";
                ddl.DataBind();
            }
            else
            {
                //normal row
                DropDownList ddl = e.Row.FindControl("DropDownListItem") as DropDownList;
                ddl.DataSource = distinctValues;
                ddl.DataTextField = "myValue";
                ddl.DataValueField = "ID";
                ddl.DataBind();
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            //footer row
            DropDownList ddl = e.Row.FindControl("DropDownListFooter") as DropDownList;
            ddl.DataSource = distinctValues;
            ddl.DataTextField = "myValue";
            ddl.DataValueField = "ID";
            ddl.DataBind();
        }
    }
