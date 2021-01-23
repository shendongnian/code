    private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
    {
        decimal price;
        if (products.TryGetValue(descriptionTextBox.Text, out price))
        {
            priceTextBox.Text = price.ToString();
        }
        else
        {
            priceTextBox.Text = string.Empty;
        }
    }
