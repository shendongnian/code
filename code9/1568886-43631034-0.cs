    private static void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Grid currentContent = sender as Grid;
        if (currentContent != null)
        {
            ComboBox comboBox = e.Source as ComboBox;
            if (comboBox != null)
            {
                ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
                if (selectedItem != null)
                {
                    String selectedItemId = selectedItem.Uid;
                    IEnumerable<Parameter> childCmBs = DataService.getServiceParametersByParentId(selectedItemId);
                    if (childCmBs != null && childCmBs.Any())
                    {
                        foreach (Parameter param in childCmBs)
                        {
                            try
                            {
                                System.Windows.Controls.ComboBox childCmB = currentContent.FindName(param.Key) as System.Windows.Controls.ComboBox;
                                if (childCmB != null)
                                {
                                    childCmB.Items.Clear();
                                    addComboBoxItems(DataService.getChildrenParameterValuesByParentId(selectedItemId), childCmB);
                                }
                            }
                            catch (Exception ex)
                            {
                                System.Windows.MessageBox.Show(String.Format("Happen some problem during creating comboboxes: {0}", ex.Message));
                            }
                        }
                    }
                }
            }
        }
    }
