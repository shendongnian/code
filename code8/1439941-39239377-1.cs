    private void jobTypeComboBox_SelectionChanged(object sender, 
               System.Windows.Controls.SelectionChangedEventArgs e)
    {
        foreach (var glassType in this.glassTypeComboBox.Items)
        {
            ComboBoxItem cbi = glassType as ComboBoxItem;
            cbi.IsEnabled = true; // always default to enabled.
            if (this.jobTypeComboBox.SelectedValue.ToString() == "Repair")
            {
                if ((cbi.Content.ToString() != "Windscreen") && 
                           (cbi.Content.ToString() != "Rearscreen"))
                {
                    cbi.IsEnabled = false;
                }
            }
            if (this.jobTypeComboBox.SelectedValue.ToString() == "Replace")
            {
                // Add more conditions... you get the idea...
            }
        }
    }
