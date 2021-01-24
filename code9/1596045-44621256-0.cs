    int cartQuantity = 0;
    if (!string.IsNullOrEmpty(qty.SelectedValue.Trim()))
    {
        if(qty.SelectedValue.Trim().All(char.IsDigit))
        {
            cartQuantity = int.Parse(qty.SelectedValue.Trim());
        }    
    }
