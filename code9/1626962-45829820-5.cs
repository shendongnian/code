    private void SetSelectedComboBoxItem(string itemName)
    {
       ComboItem selected = MyComboItems.FirstOrDefault(i => i.Name.Equals(itemName));
      if (selected != null)
      {
        SelectedItem = selected;
      }
      else
      {
        SelectedItem = combo.Items[0];
      }
    }
