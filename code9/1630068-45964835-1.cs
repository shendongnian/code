    protected void grdOperationEntry_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check if gridview row not a header or footer
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get controls by id from gridview and cast them
            Label lblDateCompletion = e.Row.FindControl("lblDateCompletion") as Label;
            TextBox txtDateCompletion = e.Row.FindControl("txtDateCompletion") as TextBox;
            if (lblDateCompletion.Text == null)
                txtDateCompletion.Visible = true;
            else
                lblDateCompletion.Visible = true;
            // perform same for other controls
        }
    }
