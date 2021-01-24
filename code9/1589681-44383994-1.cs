    if (decimal.TryParse(priceLabel2.Text, out decimal price))
    {
        total += price;
    }
    else
    {
        MessageBox.Show("Input is not a valid decimal.");
    }
