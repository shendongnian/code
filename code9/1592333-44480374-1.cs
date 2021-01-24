        private void finalizeButton_Click(object sender, EventArgs e)
            {
                foreach (var cmbObj in cartComboBox.Items)
                {
                    if (prices.Keys.Contains(cmbObj.ToString()))
                    {
                         BookTitle tempOut;
                         ListViewItem list = 
                         cartListView.Items.Add(cmbObj.ToString());
                        if (prices.TryGetValue(cmbObj.ToString(), out tempOut))
                            list.SubItems.Add(tempOut.Prices[0].ToString());
                       
                    }
                }
               
            }
