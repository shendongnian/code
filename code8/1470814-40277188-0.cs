    using(var context = new FooEntities)
    {
    	try
    	{
    	var customer = context.Customers.First(i=> i.CustomerID = 23);
    	customer.Name = "Bar";
    	context.SaveChanges();
    	//Write your notification code here
    	}
    	catch(Exception ex)
    	{
    		//Write notification along with the error you want to display.
    	}
    }
