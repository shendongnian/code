    public void txtSearch_Changed(object sender, EventArgs e)
    {
        gvBanquet.DataSource = DLBqt.SearchBanquet(txtSearch.Text.Trim());
        gvBanquet.DataBind();
    }
