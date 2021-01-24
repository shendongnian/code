    var query = (from customers in context.customers 
             group customers by customers.RegisterDateTime.Month into g 
             select new
                    { Month = g.Key, Count = g.Count(x=>x!=null) }
            ).ToList();
