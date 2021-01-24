            var editableCustomers = _ctx.Customers.ProjectTo<Customer>().ToList();
            editableCustomers.First().Name="changed";
            var customers = _ctx.Customers.ToList();
            foreach (var customer in customers)
            {
                customer.Name = editableCustomers.First(x => x.CustomerId == customer.CustomerId).Name;
            }
            _ctx.SaveChanges();
