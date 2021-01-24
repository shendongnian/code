    protected void ShowHide_Click(object sender, EventArgs e)
    {
        ImageButton btn = (ImageButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        PlaceHolder ph = gvr.FindControl("PlaceHolder1") as PlaceHolder;
        if (btn.ImageUrl.ToString() == "~/images/plus.png")
        {
            ph.Visible = true;
            btn.ImageUrl = "~/images/minus.png";
        }
        else
        {
            ph.Visible = false;
            btn.ImageUrl = "~/images/plus.png";
        }
        
    }
