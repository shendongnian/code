    private double getPrice()
        {
            int intQty = 1;
            txtQty.Text = intQty.ToString();
            double dblSalesTax = 0;
            lblSalesTax.Text = dblSalesTax.ToString(); 
            double dblPrice = double.Parse(txtPrice.Text);
            txtPrice.Text = dblPrice.ToString("c");
            return Convert.ToDouble(txtPrice.Text);
    
        }
`
