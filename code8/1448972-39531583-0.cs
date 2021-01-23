    foreach (ListItem item in dropdown1.Items)
    {
        if (item.Selected)
        {
            checkedList.Add(item.Text);
        }
    }
    dropdown1.Texts.SelectBoxCaption = String.Join(",", checkedList);
