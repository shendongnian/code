       var parent = Node.LoadNode(Order.StoragePath);
       Order order = new Order(parent);
       // Assign a bunch of fields then save the order.
       order.Save();
       
       // Do more operations -- calculate invoices, send emails, etc.
       
       // order Node is now out of date. You must reload it to 
       // perform Repository operations.
       var orderNotOutOfDate = Node.LoadNode(order.Id) as Order;
       var archiveFolder = GetArchiveFolder();
       order.MoveTo(archiveFolder);   // MoveTo fails if Node is out of date.
