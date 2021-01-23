    TaskGridView.EditIndex = 1;
    TaskGridView.DataSource = dt;
    TaskGridView.DataBind();
    TaskGridView.Width = 600;
    TaskGridView.HeaderStyle.CssClass = "header";
    TaskGridView.RowStyle.CssClass = "rowstyle";
        
    GridViewRow row = (GridViewRow)TaskGridView.Rows[TaskGridView.EditIndex];
    TextBox textnew = (TextBox)row.Cells[1].Controls[0];
    textnew.Text = "test";
