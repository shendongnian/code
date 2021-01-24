    public ServiceCallResponse GetServiceCallsDapper(ServiceCallRequest Request)
    {
    	var queryParameters = new {statuses = Request.Statuses, createDate = Request.CreateDate};
    	const string splitOn = "Number,Id"; // Id indicates beginning of second class (Technician).  Number indicates begining of third class (Customer).
    	// Note multiple columns are named "Number".  See note below about how Dapper maps columns to class properties.
    	// Note Dapper supports parameterized queries to protect against SQL injection attacks, including parameterized "where in" clauses.
    	const string query = @"sql query here..."
    	ServiceCallResponse response = new ServiceCallResponse();  // Keyed collection properties created in constructor.
    	using (IDbConnection connection = new SqlConnection("DB connection string here..."))
    	{
    		connection.Open();
    
    		// Dapper adds a generic method, Query<>, to the IDbConnection interface.
    
    		// Query<(1)ServiceCall, (2)Technician, (3)Customer, (4)ServiceCall> means
    		//   construct a (1)ServiceCall, (2)Technician, and (3)Customer class per row, add to an IEnumerable<(4)ServiceCall> collection, and return the collection.
    		
    		// Query<TFirst, TSecond, TThird, TReturn> expects SQL columns to appear in the same order as the generic types.
    		// It maps columns to the first class, once it finds a column named "Id" it maps to the second class, etc.
    		// To split on a column other than "Id", specify a splitOn parameter.
    		// To split for more than two classes, specify a comma-delimited splitOn parameter.
    
    		response.ServiceCalls.AddRange(connection.Query<ServiceCall, Technician, Customer, ServiceCall>(query, (ServiceCall, Technician, Customer) =>
    		{
    			// Notice Dapper creates many objects that will be discarded immediately (Technician & Customer parameters to lambda expression).
    			// The lambda expression sets references to existing objects, so the Dapper-constructed objects will be garbage-collected.
    			// So this is the cost of using Dapper.  We trade unnecessary object construction for simpler code (compared to constructing objects from IDataReader).
    			
    			// Each row in query results represents a single service call.
    			// However, rows repeat technician and customer data through joined tables.
    			// Avoid constructing duplicate technician and customer classes.
    		
    			// Refer to existing objects in global collections, or add Dapper-mapped objects to global collections.
    			// This avoid creating duplicate objects to represent same data.
    			// Newtonsoft JSON serializer preserves object instances from service to client.
    			Technician technician;
    			Customer customer;
    			if (response.Technicians.Contains(Technician.Id))
    			{
    				technician = response.Technicians[Technician.Id];
    			}
    			else
    			{
    				response.Technicians.Add(Technician);
    				technician = Technician;
    			}
    			if (response.Customers.Contains(Customer.Number))
    			{
    				customer = response.Customers[Customer.Number];
    			}
    			else
    			{
    				response.Customers.Add(Customer);
    				customer = Customer;
    			}
    			// Set object associations.
    			ServiceCall.Technician = technician;
    			ServiceCall.Customer = customer;
    			technician.ServiceCalls.Add(ServiceCall);
    			if (!technician.Customers.Contains(customer))
    			{
    				technician.Customers.Add(customer);
    			}
    			customer.ServiceCalls.Add(ServiceCall);
    			if (!customer.Technicians.Contains(technician))
    			{
    				customer.Technicians.Add(technician);
    			}
    			return ServiceCall;
    		}, queryParameters, splitOn: splitOn));
    	}
    	return response;
    }
