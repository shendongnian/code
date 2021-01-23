    foreach (IEnumerable<TabItem> item in tabControlList)
    {
        if (item.Header== "AddRskAreas")
        {
            item.IsSelected = true;
        }         
        else
        {
            MessageBox.Show("Tab not found");
        }
    }
