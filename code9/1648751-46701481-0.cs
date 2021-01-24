            List<SellTrhu> products = new List<SellTrhu>();
            for (int i = 1; i <= 8; i++)
            {
                SellTrhu product = new SellTrhu();
                double[] month = new double[8];
                month[i] = 201700 + i;
                amount[i] = _context.VGetSellThruSales.Where(y => y.Month == month[i]).Select(x => x.NetAmount ?? 0).Sum();
                targetAmount[i] = _context.DashboardSellThruSummary.Where(y => y.Month == month[i]).Select(x => x.Ach ?? 0).Sum();
                product.month = month[i];
                product.value = amount[i];
                product.target = targetAmount[i];
                products.Add(product);
            }
