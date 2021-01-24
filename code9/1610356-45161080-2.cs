    protected void gridviewSanPham_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // check if dropdownlist in edittemplate
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
               DropDownList drop = (DropDownList)e.Row.FindControl("cboTypeID");
               drop.DataSource = FillLoaiSP();
               drop.DataBind();
            }
        }
     }
