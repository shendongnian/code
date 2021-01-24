    foreach(GridViewRow item in GdvTestData.Rows) {
    // check row is datarow
     if (item.RowType = DataControlRowType.DataRow) {
        CheckBox chk = (item.FindControl("CheckBox3") as CheckBox);
        if (chk.Checked) 
        {
           string conn = item.Cells[1].Text;     
        }
     }
    }
