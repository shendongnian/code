    int max = 100;
    for (int i = 0; i < max; i++)
    {
        GridViewRow gvr = GridView1.Rows[i];
        if(gvr.RowType == DataControlRowType.DataRow){
            CheckBox cb = (CheckBox)gvr.FindControl("chkSelect");
            cb.Checked = true;
        }
    }
