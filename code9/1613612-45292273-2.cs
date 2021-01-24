    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e) {
        if ((e.Row.RowType == DataControlRowType.DataRow)) {
            string gender = Convert.ToString(e.Row.Cells[columnnumber].Text).Trim();
            if ((gender == "1")) {
                e.Row.Cells[columnnumber].Text = "Male";
            }
            else if ((gender == "2")) {
                e.Row.Cells[columnnumber].Text = "Female";
            }
            
        }
        
    }
