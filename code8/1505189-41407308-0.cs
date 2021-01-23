        public double GetInStockQuantity(Warehouse warehouse, Entities db)
        {
            double res;
            try
            {
                res = db.Stocks.AsNoTracking().Where(c => c.Product.ID == ID &&       c.WarehouseID == warehouse.ID).
                AsNoTracking().AsEnumerable().
                Where(c => c.InvoiceItems.Any(q => q.Invoice.IsStocked == true)).Sum(q => q.Quantity);
            }
            catch (Exception)
            {
               res = 0;
            }
              return res;
       }
