    private void SetSelectedComboBoxItem(string itemName)
    {
       ComboItem selected = MyComboItems.FirstOrDefault(i => i.Name.Equals(itemName));
      if (selected != null)
      {
        combo.SelectedItem = selected;
      }
      else
      {
        combo.SelectedItem = combo.Items[0];
      }
    }
