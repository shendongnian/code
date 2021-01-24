    // chklData is a CheckboxList control
    List<string> dataList = new List<string>(chklData.Items.Count);
    foreach (ListItem item in chklData.Items)
    {
    	if (item.Selected) { dataList.Add(item.Value); }
    }
