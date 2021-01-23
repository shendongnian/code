    var index = listBox.SelectedIndex;
    if (index != -1)
    {
        // remove item
        listBox.Items.RemoveAt(index);
        // select a new item
        if (listBox.Items.Count > index)
            listBox.SelectedIndex = index;
        else
            listBox.SelectedIndex = index - 1;
     }
     else
        MessageBox.Show("You have not selected an item");
