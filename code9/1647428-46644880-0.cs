    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image img = (Image)e.Row.FindControl("imgID");
            
            img.ImageURl = (e.Row.Cells[4].Text == "Active") ? "~/Images/Active.jpg" : "~/Images/Inactive.jpg";
        }
    }
