    // See, now you are the 'owner' of the dataRepository
    using (var dataRepository = this.dataRepositoryFactory.Create())
    {
    	if (Mode == "New")
    	{
    		Order newOrder = new Order();
    
    		int maxOrderNumber = this.dataRepository.Orders.Select(o => o.OrderNumber).DefaultIfEmpty(0).Max();
    		maxOrderNumber++;
    
    		newOrder.OrderNumber = maxOrderNumber;
    		newOrder.Date = DateTime.ParseExact(txtOrderDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
    		newOrder.CustomerID = Convert.ToInt32(ddlCustomer.SelectedValue);
    		newOrder.Status = 1;
    
    		this.dataRepository.Orders.Add(newOrder);
    
    		foreach (DataRow dt in dtOrderDetails.Rows)
    		{
    			OrderDetails newOrderDetails = new OrderDetails();
    			newOrderDetails.OrderNumer = maxOrderNumber;
    			newOrderDetails.ProductId = Convert.ToInt32(dt["ProductId"]);
    			newOrderDetails.Quantity = Convert.ToInt32(dt["Quantity"]);
    
    			newOrder.OrderDetails.Add(newOrderDetails);
    		}
    
    		myOrder = newOrder;
    	}
    
    	if (Mode == "Edit")
    	{
    		Order editedOrder = this.dataRepository.Orders.FirstOrDefault(o => o.Id == myOrder.Id);
    
    		editedOrder.Date = DateTime.ParseExact(txtOrderDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
    		editedOrder.CustomerID = Convert.ToInt32(ddlCustomer.SelectedValue);
    		editedOrder.OrderDetails.Clear();
    
    		foreach (DataRow dt in dtOrderDetails.Rows)
    		{
    			OrderDetails editedOrderDetails = new OrderDetails();
    			editedOrderDetails.OrderNumer = editedOrder.OrderNumber;
    			editedOrderDetails.ProductId = Convert.ToInt32(dt["ProductId"]);
    			editedOrderDetails.Quantity = Convert.ToInt32(dt["Quantity"]);
    
    			editedOrder.OrderDetails.Add(editedOrderDetails);
    		}
    	}
    	
    	this.dataRepository.Save();
    }
