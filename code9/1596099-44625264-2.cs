    foreach (var item in lbUsers.Items)
    {
        if (item.Content.ToString().Contains(this.tbSearch.Text))
        {
            item.Visible = true;
        }
        else
        {
            item.Visible = false;
        }
    }
