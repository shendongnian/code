    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        CheckBox chk = e.Row.Cells[1].FindControl("chk") as CheckBox;
        if (chk == null)
        {
            chk = new CheckBox();
            chk.ID = "CheckBox1";
            chk.AutoPostBack = true;
            chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
            e.Row.Cells[1].Controls.Add(chk);
        }
    }
