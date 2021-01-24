    private void comboBox_KeyUp(object sender, KeyEventArgs e)
    {
        var combobox = (ComboBox)sender;
        var ctb = combobox.Template.FindName("PART_EditableTextBox", combobox) as TextBox;
        if (ctb == null) return;
        if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift) || Keyboard.Modifiers.HasFlag(ModifierKeys.Control) || Keyboard.Modifiers.HasFlag(ModifierKeys.Alt))
        return;
        var caretPos = ctb.CaretIndex;
        combobox.IsDropDownOpen = true;
    
        CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(combobox.Items);
        itemsViewOriginal.Filter = ((o) =>
        {
            if (String.IsNullOrEmpty(combobox.Text))
            {
                return true;
            }
            else
            {
                if (((ComboBoxItem)o).Content.ToString().StartsWith(combobox.Text, true, null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        });
    
        itemsViewOriginal.Refresh();
        ctb.CaretIndex = caretPos;
    }
