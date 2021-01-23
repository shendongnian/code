     Order _order = new Order{ AddressId = 1, DeliveryNotes ="some notes", PurchaseOrderNo =1};
     _order.Items = new List< OrderItem>();
     _ordert.Items.add(new OrderItem{ ProductName =”Laptop”, Quantity =1, UserPrice =1500.00, Comment =”some testing comments”});
     repository.order.insert(_order); 
     repository.save();
      
