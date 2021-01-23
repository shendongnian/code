    protected override void OnPreInit(EventArgs e)
    {
        if (!string.IsNullOrEmpty(Page.MasterPageFile))
        {
            if (Session["NestMaster"] == "1")
            {
                //setting a MasterPage to the Masterpage of the current page
                Page.Master.MasterPageFile = "~/MasterMaster.master";
            }
        }
    }
