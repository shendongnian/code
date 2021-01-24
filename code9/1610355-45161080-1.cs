    protected void gridviewSanPham_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // check if dropdownlist in edittemplate
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
               // bind here your dropdownlist
            }
        }
     }
