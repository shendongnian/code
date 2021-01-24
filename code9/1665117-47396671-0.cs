    private void txtTradePrice_TextChanged(object sender, EventArgs e)
    {
        int tradePrice = 0;
        if(int.TryParse(txtTradePrice.Text, out tradePrice))
            txtRate.Text = (tradePrice * 12).ToString();
    }
    private void txtRate_TextChanged(object sender, EventArgs e)
    {
        int rate = 0;
        if(int.TryParse(txtRate.Text, out rate))
            txtTradePrice.Text = (rate / 12).ToString();
    }
