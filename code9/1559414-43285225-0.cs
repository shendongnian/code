    private Product getProduct(string oneProductText)
        {
            Product product = new Product();
            MatchCollection matches = Regex.Matches(oneProductText, @"(.*?)€(\d*.?\d{0,2}\s*[1-9]+\d*)\s*€(\d*.\d{0,2})↨");
            //text - price/per - amount - price total || use after broken into pieces.
            foreach (Match match in matches)
            {
                product = new Product();
                product.name = match.Groups[1].Value;
                decimal totalPrice = Decimal.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
                decimal[] priceAndAmount = getPricePerAndAmount(match.Groups[2].Value, totalPrice);
                product.price = priceAndAmount[0];
                product.amount = (int)priceAndAmount[1];
            }
            return product;
        }
    private decimal[] getPricePerAndAmount(string priceAmount, decimal totalPrice)
        {
            decimal[] priceAndAmount = new decimal[2];
            for (int i = 1; i <= priceAmount.Length - 1; i++)
            {
                decimal amount = Decimal.Parse(Right(priceAmount, i), CultureInfo.InvariantCulture);
                decimal price = Decimal.Parse(priceAmount.Substring(0, priceAmount.Length - i), CultureInfo.InvariantCulture);
                decimal tempPrice = amount * price;
                
                if (totalPrice == tempPrice)
                {
                    priceAndAmount[0] = price;
                    priceAndAmount[1] = amount;
                    break;
                }
            }
            return priceAndAmount;
        }
