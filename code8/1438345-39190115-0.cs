    void LinkOrdersToCustomer(CustomerDto dto)
    {
        using (var dbTxn = _txnFactory.NewTransaction())
        {
            var customer = _customerRepository.Get(dto.Id);
            foreach (var orderId in dto.OrderIds)
            {
                var order = _orderRepository.Get(orderId);
                customer.LinkToOrder(order);
            }
            dbTxn.Save();
        }
    }
