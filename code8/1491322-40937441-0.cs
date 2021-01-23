    protected void ImageButtonUpdate_Click(object sender, EventArgs e){
        ImageButton btnupdate= sender as ImageButton;
        btnupdate.Enabled = false;
        //if you need to get other controls in the same row
        GridViewRow row = (GridViewRow)btnupdate.NamingContainer;
        var btnedit=  (ImageButton)row.FindControl("ImageButtonEdit");
        btnedit.Enabled = false; // do enable or disable as you need
    }
