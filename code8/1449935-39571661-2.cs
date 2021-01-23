    //Populate Orders: 
    			Orders = new ObservableCollection<Order> { new Order { Address = "dsfsd", Date = DateTime.Now, Name = "Name" } ,
    				 new Order { Address = "dsfsd", Date = DateTime.Now, Name = "Name" },
    				  new Order { Address = "dsfsd", Date = DateTime.Now, Name = "Name" }
    				};
    
    			OrdersGridView.ItemsSource = Orders;
