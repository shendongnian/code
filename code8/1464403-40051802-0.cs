    foreach (Control c in myFlowLayoutPanel.Controls)
    {
        if (!c.Property.Text.ToLower().Contains(searchBox.Text.ToLower()))
        {
            myFlowLayoutPanel.Controls.Remove(c);
        }
    }
