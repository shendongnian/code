    protected void PermDelete_Click(object sender, EventArgs e)
    {
        foreach (ListItem item in DeleteListBox.Items)
        {
            if (item.Selected)
            {
                var toDelete = projects.Where(x => x.ID == Convert.ToInt32(item.Value)).FirstOrDefault();
            }
        }
    }
