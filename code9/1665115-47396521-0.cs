    private void txtTradePrice_TextChanged(object sender, EventArgs e)
    {
       if(!string.IsNullOrEmpty(txtTradePrice.Text))         
          txtRate.Text = (Convert.ToInt32(txtTradePrice.Text) * 12).ToString();
    }
    
    private void txtRate_TextChanged(object sender, EventArgs e)
    {
       if(!string.IsNullOrEmpty(txtRate.Text))    
          txtTradePrice.Text = (Convert.ToInt32(txtRate.Text) / 12).ToString();
    }
