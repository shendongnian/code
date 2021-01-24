    foreach (var item in lbUsers.Items)
    {
        if (item.Content.ToString().Contains(this.tbSearch.Text)
        {
            item.Visibility = Visibility.Visible;
        }
        else
        {
            item.Visibility = Visibility.Collapsed;
        }
    }
