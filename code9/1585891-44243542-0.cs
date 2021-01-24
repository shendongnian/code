    public decimal TotalPrice {
        get
        {
            return InvoiceProducts.Sum(product => product.Price);
        }
    }
