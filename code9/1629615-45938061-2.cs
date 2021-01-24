    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        CheckBox cb = e.Row.Cells[4].FindControl("chkbox") as CheckBox;
        if (cb == null)
        {
            cb = new CheckBox();
            cb.ID = "chkbox";
            cb.AutoPostBack = true;
            cb.CheckedChanged += new EventHandler(chkBoxChange);
            e.Row.Cells[4].Controls.Add(cb);
        }
    }
