    //I have 2 columns in my dataGridView, Id 1st amount 2nd
    //I added 3 items for testing
    List<Tuple<int, int>> cart = new List<Tuple<int,int>>();
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        if (row.Cells[0].Value != null && row.Cells[1].Value != null)
        { 
            cart.Add(new Tuple<int, int>(Convert.ToInt32(row.Cells[0].Value.ToString()),Convert.ToInt32(row.Cells[1].Value.ToString())));
                    //Now each list item will have .Item1 (productId) and .Item2 (amount)
        }
    }
    using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
    {
        //The tables you add in the dataContext are accessible by name
        Order order = new Order();
        dataContext.Orders.InsertOnSubmit(order);
        dataContext.SubmitChanges(); // Submit once so we get an orderId
        foreach (Tuple<int, int> product in cart)
        {
            OrderProduct orderProduct = new OrderProduct();
            orderProduct.OrderId = order.OrderID;
            orderProduct.ProductId = product.Item1;
            orderProduct.Amount = product.Item2;
            dataContext.OrderProducts.InsertOnSubmit(orderProduct);
        }
        dataContext.SubmitChanges();
    }
