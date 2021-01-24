       decimal finalPrice;   
       decimal totalPrice;
        private void btnCheck_Click(object sender, EventArgs e)
        {
            // TO check if txtTotalPrice is not null
            if (!string.IsNullOrEmpty(txtTotalPrice.Text))
            {
                string decimalValue = txtTotalPrice.Text.Split(',')[0];
                decimal val;
                // Try to convert it to decimal.
                if (decimal.TryParse(decimalValue, out val))
                {
                    // your logic here if able to convert it.
                    finalPrice = val- (val/ 100) * discount;
                                 
                }
            }
       }
