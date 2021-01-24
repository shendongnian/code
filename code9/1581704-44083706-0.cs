    var customerRepository = this.repositoryFactory.Create<Customer>();
    var customer = customerRepository.Query()
                                     .Where(e => e.Id == 123)
                                     .Go();
    
    var orderRepository = this.repositoryFactory.Create<Order>();
    customer.Orders = orderRepository.Query()
                                     .Where(e => e.CustomerId == 123)
                                     .Go();
