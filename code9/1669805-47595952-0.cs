    public decimal TotalSum
    {
        set
        {
            TotalSum = ShoppingCartItems.Sum(item => item.LineSum);
        }
    }
