    int[] cart = {2,4,5};//Fake cart eg. product Id's
    using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
    {
        //The tables you add in the dataContext are accessible by name
        Order order = new Order();
        dataContext.Orders.InsertOnSubmit(order);
        dataContext.SubmitChanges(); // Submit once so we get an orderId
        foreach (int productId in cart)
        {
            OrderProduct orderProduct = new OrderProduct();
            orderProduct.OrderId = order.OrderID;
            orderProduct.ProductId = productId;
            dataContext.OrderProducts.InsertOnSubmit(orderProduct);
        }
        dataContext.SubmitChanges();
    }
