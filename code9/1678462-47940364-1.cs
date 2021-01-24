    protected void WorkList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // CHECK IF ROW IS NOT IN EDIT MODE
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // CREATE A Button
            Button btn = new Button();
            btn.ID = "btnEstados";
            btn.Text = "Estados";
            // ADD BUTTON TO EACH ROW IN 2ND COLUMN
            e.Row.Cells[1].Controls.Add(btn);
        }
    }
