     protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                decimal salesPrice;
                decimal discount;
                if (decimal.TryParse(TextBox1.Text, out salesPrice))
                {
                    if (decimal.TryParse(TextBox2.Text, out discount))
                    {
                        decimal discountValue = this.CalculateDiscountValue(salesPrice, discount);
                        decimal totalPrice = this.TotalPriceCalculate(salesPrice, discount);
                        Label1.Text = discountValue.ToString("c");
                        Label2.Text = totalPrice.ToString("c");
                    }
                }
            }
        }
