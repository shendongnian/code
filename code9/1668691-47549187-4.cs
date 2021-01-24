    int index = listView2.SelectedIndex;
    if (index != -1)
    {
        MyItem items = (MyItem)listView2.Items.GetItemAt(index);
        if (items != null)
        {
             var textBoxContent = items.Menge;
         }
    }
