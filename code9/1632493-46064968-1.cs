    public IQueryable<Customer> GetCustomers(CustomerOrderSearchParameters parameters)
            {    
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                    var predicate = PredicateBuilder.True<Customer>();
                    if (!string.IsNullOrEmpty(parameters.FirstName))
                    {
                        predicate = predicate.And(x => x.FirstName.Contains(parameters.FirstName));
                    }
                    if (!string.IsNullOrEmpty(parameters.LastName))
                    {
                        predicate = predicate.And(x => x.LastName.Contains(parameters.LastName));
                    }
                    if (!string.IsNullOrEmpty(parameters.Email))
                    {
                        predicate = predicate.And(x => x.email.Contains(parameters.Email));
                    }
                    if (!string.IsNullOrEmpty(parameters.PhoneNumber))
                    {
                        predicate = predicate.And(x => x.MobilePhone.Contains(parameters.PhoneNumber) || x.HomePhone.Contains(parameters.PhoneNumber));
                    }
                    if (parameters.BrandID != null)
                    {
                        predicate = predicate.And(x => x.Logins.Where(l => l.BrandID == parameters.BrandID).Any());
                    }
                    if (parameters.ShowNoOrders == true)
                    {
                        predicate = predicate.And(x => x.Orders.Where(o => o.CustomerID != x.CustomerID).Any());
                    }                
                    return context.Customers.AsExpandable().Where(predicate);           
            }
