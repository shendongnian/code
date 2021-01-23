    using (var db = new MyEntities()){
            //use db to fetch orders 
            foreach (Order thisOrder in orders) {
                CustomerActionReturnModel thisAction = new CustomerActionReturnModel(thisOrder);
                thisAction.Order.OrderItems = new List<OrderItemReturnModel>();
                foreach (OrderItem thisItem in thisOrder.OrderItems) {
                    thisAction.Order.OrderItems.Add(new OrderItemReturnModel(thisItem));
                }
             thisResponse.CustomerActions.Add(thisAction);
            }
    }
