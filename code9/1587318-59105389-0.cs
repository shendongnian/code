    public IActionResult Save(OrderInput input)
    {
        _orderService.CreateOrder(new Order{ ... });
        _customerService.UpdateBalance(input.CustomerId, input.TotalAmount);
        // return whatever you want here...
    }
