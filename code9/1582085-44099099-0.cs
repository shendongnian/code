    double price, quantity;
    if(string.NullOrEmpty(txtPrice.Text)&&string.NullOrEmpty(txtQuantity.Text)
     {
      if (Double.TryParse(txtPrice.Text, out price)&&
        Double.TryParse(txtQuantity.Text, out quantity)) 
        {
             double subTotal = 0;
             subTotal = price * quantity;             
             txtSubTotal.Text = "" + subTotal.ToString();
        }
     }
    
