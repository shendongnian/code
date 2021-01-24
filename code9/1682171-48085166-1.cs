    foreach (var customer in customers)
    {
    	if (HasCustomerBeenModified(customer))
    	{
    		_ctx.Customers.Attach(customer)
    		_ctx.Entry(customer).State = System.Data.Entity.EntityState.Modified;
    	}
    
    	_ctx.SaveChanges();
    }
