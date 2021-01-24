    private void iterateButton_Click(object sender, EventArgs e)
    {
        var items = new List<CheckListBoxItem>();
    
        for (int index = 0; index < checkedListBox1.Items.Count; index++)
        {
            if (((CheckListBoxItem)checkedListBox1.Items[index]).IsDirty)
            {
                items.Add(new CheckListBoxItem()
                {
                    PrimaryKey = ((CheckListBoxItem)checkedListBox1.Items[index]).PrimaryKey,
                    Checked = checkedListBox1.GetItemChecked(index),
                    Description = ((CheckListBoxItem)checkedListBox1.Items[index]).Description
                });
            }
        }
    
        if (items.Count >0)
        {
            Ops.Insert(items);
        }
    }
