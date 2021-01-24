    foreach (CheckBox item in MachinesComboBox.Items.OfType<CheckBox>())
    {
        ComboBoxItem container = MachinesComboBox.ItemContainerGenerator.ContainerFromItem(item) as ComboBoxItem;
        if (item.Content.ToString().Contains(MachinFilterTextbox.Text) || MachinFilterTextbox.Text == "")
        {
            container.Visibility = Visibility.Visible;
        }
        else
        {
            container.Visibility = Visibility.Collapsed;
        }
    }
