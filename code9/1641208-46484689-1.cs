    protected void InvisButton_Click(object sender, EventArgs e)
    {
	// place your wanted code here
    gvBanquet.DataSource = DLBqt.SearchBanquet(txtSearch.Text.Trim());
    gvBanquet.DataBind();
    }
