        double price;
        double qty;
        if (Double.TryParse(txtPrice.Text, out price)&&
            Double.TryParse(txtQuantity.Text, out qty)) // if done, both are valid numbers
        {
            double subTotal = 0;
            subTotal = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtQuantity.Text);
            txtSubTotal.Text = "" + subTotal.ToString();
        }
       else{
             MessageBox.Show("Invalid Input");
        }
