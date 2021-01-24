            for (int x = 0; x < cboType.Items.Count; x++)
            {
                cboType.SelectedIndex = x;
                var typeCombo = ((ComboBox)cboType);
                var valueType = ((ComboBoxItem)typeCombo.SelectedValue);
                if (thisProductInfo.Type == valueType.Content.ToString())
                {
                    cboType.SelectedIndex = x;
                    break;
                }
            }
            //for (int x = 0; x < cboColor.Items.Count; x++)
            //{
            //    cboColor.SelectedIndex = x;
            //    var colorCombo = ((ComboBox)cboColor);
            //    var valueColor = ((ComboBoxItem)colorCombo.SelectedValue);
            //    if (thisProductInfo.Type == valueColor.Content.ToString())
            //    {
            //        cboColor.SelectedIndex = x;
            //        break;
            //    }
            //}
