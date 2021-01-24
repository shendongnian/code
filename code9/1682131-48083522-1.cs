    public decimal TotalPrice()
        {
            decimal sum = 0;
            foreach(var item in items)
            {
                sum += item.Price;
            }
            return sum;
        }
