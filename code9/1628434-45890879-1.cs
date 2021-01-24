        private PriceAndLabel PricePlacement(string serviceDescriptionText)
        {
            PriceAndLabel priceAndLabel = new PriceAndLabel();
            priceAndLabel.Price = 0f;
                        
            if (serviceDescText == "Phone Repair")
            {
               priceAndLabel.Label = "$20.00 + Parts";
               priceAndLabel.Price = 20.00f;
            }
            else if (serviceDesc.Text == "Virus Removal")
            {
              priceAndLabel.Label = "$10.00";
              priceAndLabel.Price = 10.00f;
            }
            else if (serviceDesc.Text == "Hardware Repair/Installation")
            {
              priceAndLabel.Label = "$10.00";
              priceAndLabel.Price = 10.00f;
            }
            else if (serviceDesc.Text == "Software Installation")
            {
               priceAndLabel.Label = "$5.00";
               priceAndLabel.Price = 5.00f;
            }
            else if (serviceDesc.Text == "Multiple")
            {
                priceAndLabel.Label = "$-.--";
                priceAndLabel.Price = null;
            }
            else
            {
              priceAndLabel.Label = "$0.00";
              priceAndLabel.Price = 0f;
            }
    
            return priceAndLabel;
        }
