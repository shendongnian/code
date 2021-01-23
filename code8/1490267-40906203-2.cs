    //PreInit event of your desired page
    protected override void OnPreInit(EventArgs e)
    {
        if (!string.IsNullOrEmpty(Page.MasterPageFile))
        {
            if (Session["MyStatus"] == "1")
            {
                Page.MasterPageFile = "~/MyMaster1.master";
            }
            else
            {
                Page.MasterPageFile = "~/MyMaster2.master";
            }
        }
    }
