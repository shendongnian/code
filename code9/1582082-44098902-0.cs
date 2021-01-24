    double subTotal = 0;
    double price, quantity;
    
    if (double.TryParse(txtPrice.Text, out price) && 
        double.TryParse(txtQuantity.Text, out quantity))
    {
        subTotal = price * quantity;
    }
    else
    {
        //Notify the exception
    }
