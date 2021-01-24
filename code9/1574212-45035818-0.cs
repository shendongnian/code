    protected void cbREVISION_CheckChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = ((CheckBox)sender).Parent as GridViewRow; // gets the gridview row where checkbox cliked
            GridView gv = gvr.Parent as GridView; // gets the cliked gridview or nested gridview
            CheckBox chkbox = gvr.FindControl("cbREVISION_REQD") as CheckBox; // gets checkbox from cliked gridview
            bool status = chkbox.Checked; // gets the status of the checkbox
            // here bind your nested-gridview
            gv.DataSource = dt; // dt is some data to which you set gridview
            gv.DataBind(); // binding methed to bind gridview
        }
