    Model1 myModel1 = new Model1()
      {
        NameOfCustomer = viewModel.viewModel1.NameOfCustomer
      };
    
      db.Orders.Add(myModel1);
      db.SaveChanges();
