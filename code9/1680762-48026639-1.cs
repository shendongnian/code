    protected void GridView1_RowDataBound(object sender, GridViewEditEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0) {
                ComboBox ddl = (ComboBox)e.Row.FindControl("GridviewCategoryComboBox1");
            }
        }
    }
