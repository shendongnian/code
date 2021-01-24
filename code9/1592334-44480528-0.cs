        private void finalizeButton_Click(object sender, EventArgs e)
        {
            foreach (var comboItem in cartComboBox.Items)
            {
                if (prices.Keys.Contains(comboItem.ToString()))
                {
                    BookTitle bt = prices[comboItem.ToString()];
                    ListViewItem list = cartListView.Items.Add(comboItem.ToString());
                    foreach (var p in bt.Prices)
                    {
                        list.SubItems.Add(p);
                    }
                }
            }
        }
