    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            int SalesPrice = Convert.ToInt32(TextBox1.Text);
            double DiscountPercentage= Convert.ToDouble(TextBox2.Text);
            double discountValue = this.CalculateDiscountValue(SalesPrice, DiscountPercentage);
            double TotalPrice = this.TotalPriceCalculate(SalesPrice, discountValue);
            Label1.Text = discountValue.ToString("c");
            Label2.Text = TotalPrice.ToString("c"); 
            
        }
    }
    protected double CalculateDiscountValue(int SalesPrice, double DiscountPercentage)
    {
        doubl discountAmount = SalesPrice * DiscountPercentage;
        return discountAmount; 
    }
    protected double TotalPriceCalculate(int SalesPrice, double disountAmount)
    {
         double TotalPrice = SalesPrice - discountAmount;
         return TotalPrice; 
    }
