    class SportGoods
        {
    
            public decimal GrandTotal { get; set; }
            public decimal SubTotal { get; set; }
            public string State { get; set; }
            public decimal SalesTax { get; set; }
            public decimal ShippingAmount { get; set; }
            public decimal AZTax = 1.05m;
            public decimal CATax = 1.10m;
            public decimal LessThan50 = 12.99m;
            public decimal FiftyTo100 = 4.99m;
    
            public SportGoods(decimal subTotal, decimal salesTax, decimal 
            shippingAmount, decimal grandTotal)
            {
                SubTotal = subTotal;
                SalesTax = salesTax;
                ShippingAmount = shippingAmount;
                GrandTotal = grandTotal;
    
            }
            /* Remove this. It is redundant as SubTotal can do the same. */
            //public decimal subTotal
            //{
            //    set
            //    {
            //        SubTotal = value;
            //    }
            //}
    
            /* Make this private, we don't need to expose this. 
             * We just need to expose something simple and straight forward. */
            private void CalculateSalesTax()
            {
                if (State == "AZ")
                {
                    SalesTax = (SubTotal * AZTax) - SubTotal;
                }
                else if (State == "CA")
                {
                     SalesTax = (SubTotal * CATax) - SubTotal;
                }
                else
                {
                    SalesTax = 0;
                }
            }
    
            /* Make this private, we don't need to expose this. 
             * We just need to expose something simple and straight forward. */
            private void CalculateShipCost()
            {
               if (SubTotal >= 0 && SubTotal < 50 )
               {
                    ShippingAmount = LessThan50;
               }
               else if (SubTotal >= 50 && SubTotal < 100)
               {
                    ShippingAmount = FiftyTo100;
               }
               else if (SubTotal >= 100)
               {
                   ShippingAmount = 0;
               }
               /* Do checking elsewhere. Removed input invalid. */
            }
    
            /* Make this private, we don't need to expose this. 
             * We just need to expose something simple and straight forward. */
            private void CalculateGrandTotal()
            {
                GrandTotal = SubTotal + SalesTax + ShippingAmount;
            }
    
            /* Expose this. Just simple method name called "PerformCalculation". Clear cut. */
            public void PerformCalculation()
            {
                CalculateSalesTax();
                CalculateShipCost();
                CalculateGrandTotal();
            }
        }
