    private void lvDisplay_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lvDisplay.SelectedItems.Count>0)
        {
            ListViewItem item = lvDisplay.SelectedItems[0];
            lblName.Text = item.SubItems[0].Text;
            lblPhone.Text = vendorPhones[item.SubItems[0].Text]; // Get the phone number from dictionary by using the vendor name.
        }
        else
        {
            lblName.Text = string.Empty;
            lblPhone.Text = string.Empty;
        }
    }
