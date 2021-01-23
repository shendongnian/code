    private void passwordListView_SelectedIndexChanged(object sender, EventArgs e)
    {
    	if(passwordListView.SelectedItems.Count > 0)
    		passwordTextBox.Text = passwordListView.SelectedItems.First().Text;
    }
