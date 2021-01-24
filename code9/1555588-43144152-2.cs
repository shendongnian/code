    if (ExpandableTextBox.Text != "")
    {
        int outexpmem;
        if (!int.TryParse(ExpandableTextBox.Text, out outexpmem))
        {
            ValidationMessage(ExpandableTextBox, "Expandable memory can only numbers!");
            return false;
        }
      if (ExpandableMemUnitComboBox.Text.Trim() == "")
        {
            ValidationMessage(ExpandableMemUnitComboBox, "Please select a Memory Unit!");
            return false;
        }
    }
