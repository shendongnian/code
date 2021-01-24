    private void finalizeButton_Click(object sender, EventArgs e)
        {
            foreach (var cmbObj in cartComboBox.Items)
            {
                if (prices.Keys.Contains(cmbObj.ToString()))
                {
                   cartListView.Items.Add(cmbObj.ToString());
                   
                }
            }
           
        }
