    foreach(GridViewRow item in GdvTestData.Rows) {
    // check row is datarow
     if (item.RowType == DataControlRowType.DataRow) {
        CheckBox chk = (item.FindControl("CheckBox3") as CheckBox);
        if (chk.Checked) 
        {          
           Label MyLabel = (Label)item.FindControl("lbl_conn");  
           string conn = MyLabel.Text;   
        }
     }
    }
