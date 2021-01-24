    List<String> newItemList = new List<string>();
    private void AddButton_Click(object sender, EventArgs e)
    {
        string newItem = NameTextBox.Text + "\t" +  QuantityBox.Value.ToString() + "\t" + PriceBox.Text;
        newItemList.Add(newItem);
        BasketBox.Text = String.Join(Environment.NewLine, newItemList);
    }
        
