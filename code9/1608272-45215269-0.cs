    protected void Page_LoadComplete(object sender, EventArgs e){
        foreach(GridViewRow row in GridView1.Rows){
           ImageButton but = (ImageButton)row.FindControl("YourButtonID");           
           if(blabla){
             disableButton(but);
            }
        }
    }
        private void disableButton(ImageButton btn_delete)
        {
            btn_delete.Enabled = false;
            btn_delete.ImageUrl = "~/Pics/delete_small_disabled.gif";
        }
        private void enableButton(ImageButton btn_delete)
        {
            btn_delete.Enabled = true;
            btn_delete.ImageUrl = "~/Pics/delete_small.gif";
        }
