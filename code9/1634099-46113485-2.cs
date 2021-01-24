    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ImageButton img = sender as ImageButton;
        GridViewRow grv = img.Parent as GridViewRow;
        if (e.CommandName == "mybutton")
        {
            FileUpload fil1 = grv.FindControl("fil1") as FileUpload;
            fil1.AllowMultiple = false;
        }
    }
