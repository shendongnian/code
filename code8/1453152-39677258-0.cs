    protected void addButton_Click(object sender, EventArgs e)
    {
        Session["Amount"] = 0;
        var dollA = new List<decimal>();
        int i = 0;
        for (i = 0; i < 4; i++) { 
            weightInteger = int.Parse(weightTextBox.Text);
            quantityInteger = int.Parse(quanTextBox.Text);
            priceDecimal = decimal.Parse(priceTextBox.Text);
            // Calculate the current item price.
            currentPriceDecimal = priceDecimal * quantityInteger;
            // Format and display the current item price.
            currentTextBox.Text = currentPriceDecimal.ToString("C");
            // Calculate the dollar amount due.
           dollarAmountDecimal += currentPriceDecimal;
            dollA.Add(dollarAmountDecimal);
            dollDec = dollA.Sum();
            Session["Amount"] += dollDec;
        }
    }
