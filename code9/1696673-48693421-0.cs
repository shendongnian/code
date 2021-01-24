        using (FinanceDBContext financeDBContext = new FinanceDBContext())
        {
            foreach (var item in priceList)
            {
                item.Apimapping = null;
                financeDBContext.Price.Add(item);
            }
            
            financeDBContext.SaveChanges();
        }
