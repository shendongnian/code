    foreach(var order in orders.Orderlines) {
        bool isValid = true;
        foreach(var product in order.Products) {
           if (DateTime.Compare(product.UseByDate, DateTime.Now) > 0) {
                isValid = false;
           }
        }
        if (isValid = false) {
            orders.OrderLines.Remove(order);
        }
     }
