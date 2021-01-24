            private void Button_Click(object sender, RoutedEventArgs e)
        {
            //create the combo box
            var comboBox = new ComboBox();
            //add the items to it
            comboBox.Items.Add("1");
            comboBox.Items.Add("2");
            //if there are no items in the relative panel, then the first combo box should go at the top
            if (RelPanel.Children.Count == 0)
            {
                RelPanel.Children.Add(comboBox);
                RelativePanel.SetAlignTopWithPanel(comboBox, true);
            }
            else
            {
                //if there are items already, the new combo box goes below the last one added
                RelativePanel.SetBelow(comboBox, RelPanel.Children.Last());
                RelPanel.Children.Add(comboBox);
            }
        }
