    public double GetSales()
    {
     return Transactions.Sum(x=>x.Quantity);
    }
    //at the end of your code use:
    .Where(x=>x.GetSales()>0);
