    private void txtTradePrice_TextChanged(object sender, EventArgs e)
    {
       if(!string.IsNullOrEmpty(txtTradePrice.Text))
       {        
         int number;
         if(Int32.TryParse(txtTradePrice.Text, out number))          
           txtRate.Text = (number * 12).ToString();
       }
    }
    
    private void txtRate_TextChanged(object sender, EventArgs e)
    {
       if(!string.IsNullOrEmpty(txtRate.Text))    
       {
          int number;          
          if(Int32.TryParse(txtRate.Text, out number))          
             txtTradePrice.Text = (number / 12).ToString();
       }
    }
