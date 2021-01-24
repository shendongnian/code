    private void AddButton_Click(object sender, EventArgs e)
        {
            string newItem = NameTextBox.Text + "\t" +  QuantityBox.Value.ToString() + "\t" + PriceBox.Text;
            List<String> newItemList = new List<string>();
            newItemList.Add(newItem);
            for(int i = 0; i < newItemList.Count; i++)
            {
                BasketBox.Text += newItemList[i] + "\n"; // this will add the text to your box
            }
        }
