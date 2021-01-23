    protected void GridViewLehrling_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Edit)
            {
                DropDownList ddlBackEnd = (DropDownList)e.Row.FindControl("DropDownListDienstleistung");
                HiddenField hdnBackEnd = (HiddenField)e.Row.FindControl("HiddenFieldGutscheinartID");
            }           
        }
    }
