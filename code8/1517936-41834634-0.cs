        if (e.CurrentValue==CheckState.Unchecked)
        {
           string item = ListFieldsOriginal.Items[item];
           ListUserSelection.Items.Add(item);
        }
        else
        {
           string item = ListFieldsOriginal.Items[item];
           ListUserSelection.Items.Remove(item);
        }
