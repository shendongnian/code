     private void txtSubTotal_TextChanged(object sender, EventArgs e)
      {
       double subTotal = 0;       
       if(string.NullOrEmpty(txtPrice.Text)&&string.NullOrEmpty(txtQuantity.Text)
      {
              subTotal = Convert.ToDouble(txtPrice.Text) * 
              Convert.ToDouble(txtQuantity.Text);
               txtSubTotal.Text = "" + subTotal;
      }
    }
