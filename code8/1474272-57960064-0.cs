    IEnumerable<CustomerOrder.BusinessObjects.Customer> ICustomerDao.GetAllCustomers()
            {
                using (var customerOrderContext = new Entities())
                {
                    return (from customer in customerOrderContext.Customers
    
                            select customer).ToList();
                }
            }
